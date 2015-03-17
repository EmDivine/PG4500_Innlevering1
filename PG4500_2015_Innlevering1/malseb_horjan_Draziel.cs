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

		public override void Run()
		{
			_gunner = new Gunner(this);
			_scout = new Scout(this);
			_driver = new Driver(this);
			_fsm = new StateMachine(this);
			//_wallAvoid = new WallAvoidance(this);
			GameLoop();
		}

		public void GameLoop()
		{
			
			//Search();
			SetAhead(2000);					
			Execute();
			while (Time < 1000)
			{
				if ((Math.Min(this.X, BattleFieldWidth - this.X) < (this.Height + 30)) || (Math.Min(this.Y, BattleFieldHeight - this.Y) < (this.Height + 30)))
				{
					this.MaxVelocity = 0;
					SetTurnRight(Heading - 180);
					WaitFor(new TurnCompleteCondition(this));
					SetAhead(2000);
					MaxVelocity = 8;
					WaitFor(new MoveCompleteCondition(this));
				}
				
				Execute();
			}
			
		}

		public void Search()
		{
			//if (no lock-on) {}
			if (_fsm.State != States.SEARCH)
			{
				_fsm.State = States.SEARCH;
			}
			while (_fsm.State == States.SEARCH)
			{
				_scout.Sweep();
			Execute();
			}
		}

		public override void OnScannedRobot(ScannedRobotEvent e)
		{
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
	}
}
