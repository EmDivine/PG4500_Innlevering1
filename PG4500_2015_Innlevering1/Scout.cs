using Robocode;

namespace Robot_support_classes
{
	class Scout
	{
		private AdvancedRobot robot;
		public Scout(AdvancedRobot robot)
		{
			this.robot = robot;
			robot.IsAdjustRadarForGunTurn = true;
		}

		public void sweep()
		{
			robot.SetTurnRadarRight(Rules.RADAR_TURN_RATE);
		}
	}
}
