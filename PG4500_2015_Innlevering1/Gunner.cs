using Robocode;

namespace Robot
{
	class Gunner
	{
		private AdvancedRobot _robot;
		public Gunner(AdvancedRobot robot)
		{
			_robot = robot;
			_robot.IsAdjustGunForRobotTurn = true;
		}

		public void Predict(double targetX, double targetY, double targetVelocity, double targetHeading)
		{
			//
		}
	}
}
