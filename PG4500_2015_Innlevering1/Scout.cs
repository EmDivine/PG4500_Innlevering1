using Robocode;
using System.Collections.Generic;

namespace Robot_support_classes
{
	class Scout
	{
		private AdvancedRobot robot;
		private List<string> enemyNames;

		public Scout(AdvancedRobot robot)
		{
			this.robot = robot;
			robot.IsAdjustRadarForGunTurn = true;
			enemyNames = new List<string>();
		}

		public void sweep()
		{
			robot.SetTurnRadarRight(360);
			robot.WaitFor(new RadarTurnCompleteCondition(robot, 2));
		}

		public void countEnemies(string name)
		{
			if (!enemyNames.Contains(name))
			{
				enemyNames.Add(name);
				robot.Out.WriteLine("{1}\t# Enemy \"{0}\" spotted and registered.", name, robot.Time);
			}
		}

		public void killEnemy(string name)
		{
			if (enemyNames.Contains(name))
			{
				robot.Out.WriteLine("{0}\t# Enemy \"{1}\" died and was removed from registry.", robot.Time, name);
				enemyNames.Remove(name);
			}
			else
			{
				robot.Out.WriteLine("{0}\t# Enemy \"{1}\" died the way he lived: unknown.", robot.Time, name);
			}
		}
	}
}
