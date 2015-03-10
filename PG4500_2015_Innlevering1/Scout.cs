using Robocode;

namespace Robot_support_classes
{
	class Scout
	{
		private AdvancedRobot robot;
		public Scout(AdvancedRobot robot)
		{
			this.robot = robot;
		}

		public void sweep()
		{
			robot.SetTurnRadarRight(360);
		}
	}
}
