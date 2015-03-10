using Robocode;
using System.Collections.Generic;

namespace Robot_support_classes
{
	class Scout
	{
		private AdvancedRobot robot;
		//private int enemyCount;
		private List<string> enemyNames;

		public Scout(AdvancedRobot robot)
		{
			this.robot = robot;
			robot.IsAdjustRadarForGunTurn = true;
		}

		public void sweep()
		{
			robot.SetTurnRadarRight(Rules.RADAR_TURN_RATE);
		}

		public void countEnemies(string name)
		{
			if (!enemyNames.Contains(name))
			{
				enemyNames.Add(name);
				robot.Out.WriteLine("{1}\t# enemy \"{0}\" spotted and registered.", name, robot.Time);
			}
		}

		public int enemyCount
		{
			get
			{
				return enemyNames.Count;
			}
		}

		//public int enemies
		//{
		//	get
		//	{
		//		return enemyCount;
		//	}
		//	private set
		//	{
		//		enemyCount = value;
		//	}
		//}

		class EnemyFiredEvent : Event
		{

		}
	}
}
