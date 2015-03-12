using Robocode;
using System.Collections.Generic;

namespace Robot_support_classes
{
	class Scout
	{
		private AdvancedRobot _robot;
		private List<string> _enemyNames;

		public Scout(AdvancedRobot robot)
		{
			_robot = robot;
			_robot.IsAdjustRadarForGunTurn = true;
			_enemyNames = new List<string>();
		}

		public void Sweep()
		{
			_robot.SetTurnRadarRightRadians(double.PositiveInfinity);
            _robot.Execute();
            
            //_robot.WaitFor(new RadarTurnCompleteCondition(_robot, 2));
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
	}
}
