using Robocode;
using Robot.Coordinates;

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

		public void Predict(Vector2 targetPosition, Polar2 targetHeading)
		{
			Polar2 predictedPosition = targetPosition + targetHeading;
			_robot.Out.WriteLine("{0}\t# trying to predict opponent; angle: {1}", _robot.Time, GunBearing- predictedPosition.Angle);
			_robot.SetTurnGunRight(GunBearing - predictedPosition.Angle);
			if (_robot.GunTurnRemaining < 5)
			{
				_robot.SetFire(1);
			}
		}

		public void OnScannedRobot(ScannedRobotEvent e)
		{
			Predict(new Polar2(e.Distance, e.Bearing - _robot.Heading), new Polar2(e.Velocity, e.Heading));
		}

		private double GunBearing
		{
			get
			{
				return Robocode.Util.Utils.NormalRelativeAngleDegrees(_robot.GunHeading - _robot.Heading);
			}
		}
	}
}
