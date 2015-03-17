using System;
using Robocode;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
	class WallAvoidance
	{
		private AdvancedRobot _robot;
		private double _minDist;
		private double _battlefieldWidth;
		private double _battlefieldHeight;

		public WallAvoidance(AdvancedRobot robot)
		{
			_robot = robot;
			_minDist = _robot.Height;
			_battlefieldWidth = _robot.BattleFieldWidth;
			_battlefieldHeight = _robot.BattleFieldHeight;
		}

		public bool test()
		{
			if (Math.Min(_robot.X, _battlefieldWidth - _robot.X) < _minDist)
			{
				return true;
			}
			else if (Math.Min(_robot.Y, _battlefieldHeight - _robot.Y) < _minDist)
			{
				return true;
			}
			return false;
		}
	}
}
