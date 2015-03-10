using Robocode;

namespace Robot_support_classes
{
	class Scout
	{
		private AdvancedRobot robot;
		private int enemyCount;

		public Scout(AdvancedRobot robot)
		{
			this.robot = robot;
			robot.IsAdjustRadarForGunTurn = true;
		}

		public void sweep()
		{
			robot.SetTurnRadarRight(Rules.RADAR_TURN_RATE);
		}

		public int EnemyCount
		{
			get
			{
				return enemyCount;
			}
			set
			{
				enemyCount = value;
			}
		}

		class EnemyFiredEvent : Event
		{
			
		}
	}
}
