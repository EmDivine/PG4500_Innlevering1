using Robocode;
using Robocode.Util;
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
			Polar2 predictedPosition = targetPosition;// +targetHeading;
			_robot.SetTurnGunRight(Utils.NormalRelativeAngleDegrees(predictedPosition.Angle + GunBearing));

			_robot.Out.WriteLine("{0}\t# target position: {1}", _robot.Time, (Vector2)predictedPosition);

			if (_robot.GunTurnRemaining < 5)
			{
				_robot.SetFire(1);
			}
		}

		public void OnScannedRobot(ScannedRobotEvent e)
		{
			//Predict(new Polar2(e.Distance, e.Bearing + _robot.Heading), new Polar2(e.Velocity, e.Heading));
			Predict(new Polar2(e.Distance, e.Bearing),new Polar2());
		}

		private double GunBearing
		{
			get
			{
				return _robot.Heading - _robot.GunHeading;
			}
		}

		private Vector2 RobotPosition
		{
			get
			{
				return new Vector2(_robot.X, _robot.Y);
			}
		}
	}
}
