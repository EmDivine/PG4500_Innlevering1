using Robocode;
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
				Search();
			}
		}

		public void Search()
		{
			//if (no lock-on) {}
			if (fsm.State != "SEARCH")
			{
				fsm.SwitchState("SEARCH");
			}
			
			scout.sweep();
			Execute();
		}

		public override void OnScannedRobot(ScannedRobotEvent evnt)
		{

		}

		public override void OnRobotDeath(RobotDeathEvent evnt)
		{
			scout.OnEnemyDeath(evnt.Name);
		}

		public override void OnDeath(DeathEvent evnt)
		{
			Out.WriteLine("{0}\t# ALL SYSTEMS DOWN! I REPEAT, ALL SYSTE...", Time);
		}

	}
}
