using Robocode;
using Robot_support_classes;

namespace PG4500_2015_Innlevering1
{
	public class malseb_horjan_Robot : AdvancedRobot
	{

		private Gunner _gunner;
		private Scout _scout;
		private Driver _driver;
		private StateMachine _fsm;

		public override void Run()
		{
			_gunner = new Gunner(this);
			_scout = new Scout(this);
			_driver = new Driver(this);
			_fsm = new StateMachine(this);

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
			if (_fsm.State != "SEARCH")
			{
				_fsm.SwitchState("SEARCH");
			}
			
			_scout.Sweep();
			Execute();
		}

		public override void OnScannedRobot(ScannedRobotEvent evnt)
		{

		}

		public override void OnRobotDeath(RobotDeathEvent evnt)
		{
			_scout.OnEnemyDeath(evnt.Name);
		}

		public override void OnDeath(DeathEvent evnt)
		{
			Out.WriteLine("{0}\t# ALL SYSTEMS DOWN! I REPEAT, ALL SYSTE...", Time);
		}

	}
}
