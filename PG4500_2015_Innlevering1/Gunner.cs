using Robocode;

namespace Robot_support_classes
{
	class Gunner
	{
		private AdvancedRobot robot;
		public Gunner(AdvancedRobot robot)
		{
			this.robot = robot;
			robot.IsAdjustGunForRobotTurn = true;
		}
	}
}
