using PG4500_2015_Innlevering1;
using Robocode;
using Robocode.Util;
using Robot.Coordinates;

namespace Robot
{
	class Gunner
	{
		private malseb_horjan_Draziel _robot;
		public Gunner(malseb_horjan_Draziel robot)
		{
			_robot = robot;
			_robot.IsAdjustGunForRobotTurn = true;
		}

		public void onScannedRobot(Polar2 targetPosition, Polar2 targetHeading)
		{
			AimAt(targetPosition + targetHeading * (targetPosition.Magnitude / Rules.GetBulletSpeed(1)));
		}

		private void AimAt(Vector2 targetPosition)
		{
			Polar2 targetRelativePosition = targetPosition - _robot.Position;
			_robot.SetTurnGunRight(Utils.NormalRelativeAngleDegrees(90 - targetRelativePosition.Angle - _robot.GunHeading));
		}
	}
}
