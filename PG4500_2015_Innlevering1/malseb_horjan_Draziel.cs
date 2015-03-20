using Robocode;
using Robocode.Util;
using Robot;
using System;
using Robot.Coordinates;

namespace PG4500_2015_Innlevering1
{
	public class malseb_horjan_Draziel : AdvancedRobot
	{
		private Gunner _gunner;
		private Scout _scout;
		private Driver _driver;
		private StateMachine _fsm;
		private WallAvoidance _wallAvoid;

		public Vector2 Position
		{
			get
			{
				return new Vector2(X, Y);
			}
		}

		public override void Run()
		{
			_gunner = new Gunner(this);
			_scout = new Scout(this);
			_driver = new Driver(this);
			_fsm = new StateMachine(this);
			_wallAvoid = new WallAvoidance(this);

			GameLoop();
		}

		public void GameLoop()
		{
			while (true)
			{

			}
			Search();
			
		}

		

		public void Search()
		{
			//if (no lock-on) {}
			_fsm.State = States.SEARCH;
			while (_fsm.State == States.SEARCH)
			{
				_scout.Sweep();
				Execute();
			}
		}

		public override void OnScannedRobot(ScannedRobotEvent e)
		{
			_fsm.State = States.ENGAGE;
			_scout.OnScannedRobot(e);
			_gunner.OnScannedRobot(e);
		}

		public override void OnRobotDeath(RobotDeathEvent e)
		{
			_scout.OnRobotDeath(e.Name);
		}

		public override void OnDeath(DeathEvent e)
		{
			Out.WriteLine("{0}\t# ALL SYSTEMS DOWN! I REPEAT, ALL SYSTE...", Time);
		}

		public override void OnWin(WinEvent evnt)
		{
			_fsm.State = States.IDLE;
		}

		public override void OnHitByBullet(HitByBulletEvent evnt)
		{
			Out.WriteLine("OW!");
		}
	}
}
