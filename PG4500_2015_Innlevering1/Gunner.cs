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

		public void Predict(Polar2 targetPosition, Polar2 targetHeading)
		{
			//_robot.SetTurnGunRight(Utils.NormalRelativeAngleDegrees(targetPosition.Angle - GunBearing));
			AimAt(targetPosition + targetHeading * ((targetPosition+targetHeading).Magnitude/Rules.GetBulletSpeed(1)));
		}

		public void OnScannedRobot(ScannedRobotEvent e)
		{
			Predict(new Polar2(e.Distance, e.Bearing), new Polar2(e.Velocity, e.Heading));
		}

		private double GunBearing
		{
			get
			{
				return _robot.GunHeading - _robot.Heading;
			}
		}

		//TODO make this
		private void AimAt(Vector2 targetPosition)
		{
			Polar2 targetRelativePosition = targetPosition - _robot.Position;
			_robot.SetTurnGunRight(Utils.NormalRelativeAngleDegrees(90 - targetRelativePosition.Angle - _robot.GunHeading));
		}
	}
}
