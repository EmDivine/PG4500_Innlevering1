using Robocode;
using Robocode.Util;
using Robot.Coordinates;
using PG4500_2015_Innlevering1;

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

		private double GunBearing
		{
			get
			{
				return _robot.GunHeading - _robot.Heading;
			}
		}

		private void AimAt(Vector2 targetPosition)
		{
			Polar2 targetRelativePosition = targetPosition - _robot.Position;
			_robot.SetTurnGunRight(Utils.NormalRelativeAngleDegrees(90 - targetRelativePosition.Angle - _robot.GunHeading));
		}
	}
}
