using Robocode;
using Robocode.Util;
using System.Collections.Generic;

namespace Robot
{
	class Scout
	{
		private AdvancedRobot _robot;
		private long _timeSpotted;
		private List<string> _enemyNames;

		public Scout(AdvancedRobot robot)
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
				_robot.Out.WriteLine("{0}\t# Sweeping. _timeSpotted = {1}.", _robot.Time, _timeSpotted);
				_robot.SetTurnRadarRight(360);
			}
		}
		public void RegisterEnemy(string name)
		{
			if (!_enemyNames.Contains(name))
			{
				_enemyNames.Add(name);
				_robot.Out.WriteLine("{1}\t# Enemy \"{0}\" spotted and registered.", name, _robot.Time);
			}
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
