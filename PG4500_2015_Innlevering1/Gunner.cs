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
			_robot.SetTurnGunRight(Utils.NormalRelativeAngleDegrees(targetPosition.Angle + GunBearing));
			_robot.DebugProperty["targetAngle"] = targetHeading.Angle.ToString();

			if (System.Math.Abs(_robot.GunTurnRemaining) < 5)
			{
				_robot.SetFire(1);
			}
		}

		public void OnScannedRobot(ScannedRobotEvent e)
		{
			Predict(new Polar2(e.Distance, e.Bearing), new Polar2());
		}

		private double GunBearing
		{
			get
			{
				return _robot.Heading - _robot.GunHeading;
			}
		}

		//TODO make this
		private void AimAt(Polar2 target)
		{

		}
	}
}
