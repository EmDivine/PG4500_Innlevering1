using Robocode;
using Robot_support_classes;

namespace PG4500_2015_Innlevering1
{
	public class malseb_horjan_Robot : AdvancedRobot
	{

		private Gunner gunner;
		private Scout scout;
		private Driver driver;


		public override void Run()
		{
			gunner = new Gunner(this);
			scout = new Scout(this);
			driver = new Driver(this);

		}

		public override void OnScannedRobot(ScannedRobotEvent evnt)
		{

		}

	}
}
