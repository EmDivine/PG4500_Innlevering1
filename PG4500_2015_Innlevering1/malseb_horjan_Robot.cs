using Robocode;
using System;
using Robot_support_classes;

namespace PG4500_2015_Innlevering1
{
	public class malseb_horjan_Robot : AdvancedRobot
	{

		private Gunner gunner;
		private Scout scout;
		private Driver driver;
		private StateMachine fsm;

		public override void Run()
		{
			gunner = new Gunner(this);
			scout = new Scout(this);
			driver = new Driver(this);
			fsm = new StateMachine(this);

			GameLoop();
		}

		public void GameLoop()
		{
			while (true)
			{
				//if (Others < 1)
				//{
					fsm.SwitchState("SEARCH");
					scout.sweep();
				//}
					Execute();
			}
		}

		public override void OnScannedRobot(ScannedRobotEvent evnt)
		{

		}

		public override void OnRobotDeath(RobotDeathEvent evnt)
		{
			scout.killEnemy(evnt.Name);
		}

	}
}
