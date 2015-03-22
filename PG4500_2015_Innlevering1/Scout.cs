using Draziel.Coordinates;
using PG4500_2015_Innlevering1;
using Robocode;
using Robocode.Util;
using System.Collections.Generic;

namespace Draziel
{
	class Scout
	{
		private malseb_horjan_Draziel _robot;
		private long _timeSpotted;
		private List<string> _enemyNames;
		private Vector2 _targetPosition;

		public Vector2 TargetPosition
		{
			get
			{
				return _targetPosition;
			}
			private set
			{
				_targetPosition = value;
				_robot.DebugProperty["target's position"] = _targetPosition;
			}
		}
		public bool HaveTarget
		{
			get
			{
				return _timeSpotted + 3 > _robot.Time;
			}
		}

		public Scout(malseb_horjan_Draziel robot)
		{
			_robot = robot;
			_robot.IsAdjustRadarForGunTurn = true;
			_enemyNames = new List<string>();
			_timeSpotted = _robot.Time;
		}

		public void Sweep()
		{
				_robot.SetTurnRadarRight(360);
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
			TargetPosition = findTargetPosition(e.Distance, e.Bearing);
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
