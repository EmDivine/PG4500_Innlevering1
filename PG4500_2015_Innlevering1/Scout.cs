using Robocode;
using Robocode.Util;
using System.Collections.Generic;
using Robot.Coordinates;
using PG4500_2015_Innlevering1;

namespace Robot
{
	class Scout
	{
		private malseb_horjan_Draziel _robot;
		private long _timeSpotted;
		private List<string> _enemyNames;
		private Vector2 _enemyPosition;

		public Vector2 EnemyPosition
		{
			get
			{
				return _enemyPosition;
			}
			private set
			{
				_enemyPosition = value;
				_robot.DebugProperty["EnemyPosition"] = _enemyPosition;
			}
		}

		public Scout(malseb_horjan_Draziel robot)
		{
			_robot = robot;
			_robot.IsAdjustRadarForGunTurn = true;
			_enemyNames = new List<string>();
			_timeSpotted = -1000;
		}

		public void Sweep()
		{
			_robot.Scan();
			if (_robot.Time > _timeSpotted + 100)
			{
				_robot.SetTurnRadarRight(360);
			}
		}

		private void RegisterEnemy(string name)
		{
			if (!_enemyNames.Contains(name))
			{
				_enemyNames.Add(name);
				_robot.Out.WriteLine("{1}\t# Enemy \"{0}\" spotted and registered.", name, _robot.Time);
			}
		}

		private Vector2 findTargetPosition(double distance, double bearing)
		{
			return _robot.Position + new Polar2(distance, -bearing - _robot.Heading + 90);
		}

		public void OnRobotDeath(string name)
		{
			if (_enemyNames.Contains(name))
			{
				_robot.Out.WriteLine("{0}\t# Enemy \"{1}\" died and was removed from registry.", _robot.Time, name);
				_enemyNames.Remove(name);
			}
			else
			{
				_robot.Out.WriteLine("{0}\t# Enemy \"{1}\" died the way he lived: unknown.", _robot.Time, name);
			}
		}

		public void OnScannedRobot(ScannedRobotEvent e)
		{
			RegisterEnemy(e.Name);

			//Getting the absolute bearing of the target.
			double radarTurn = e.Bearing + RadarBearing;

			_robot.SetTurnRadarRight(Utils.NormalRelativeAngleDegrees(radarTurn));
			_timeSpotted = _robot.Time;
			EnemyPosition = findTargetPosition(e.Distance, e.Bearing);
		}

		private double RadarBearing
		{
			get
			{
				return _robot.Heading - _robot.RadarHeading;
			}
		}
	}
}
