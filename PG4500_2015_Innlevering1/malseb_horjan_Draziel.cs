using Robocode;
using Robocode.Util;
using Robot;
using System;
using Robot.Coordinates;
using System.Collections.Generic;

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
			AddCustomEvent(new Condition("Near Wall", 19, (b) => _driver.NearWall));
			AddCustomEvent(new Condition("No Target", 18, (b) => !_scout.HaveTarget));
			AddCustomEvent(new Condition("Ready to fire", 50, (b) => Math.Abs(GunTurnRemaining) < 2));
           // AddCustomEvent(new Condition("Near Bot", 20, (b) => _driver.NearBot));

			GameLoop();
		}

		public void GameLoop()
		{
			while (true)
			{
				_driver.Drive();
				//if (!_scout.HaveTarget)
				//{
				//	Search();
				//}
				/*else if (_scout.HaveTarget)
				{
					//Engange
				}*/
				//if (_driver.NearWall)
				//{
				//	_driver.Evade();
				//}
				Execute();

			}

		}



		public void Search()
		{
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

		public override void OnCustomEvent(CustomEvent evnt)
		{
			if (evnt.Condition.Name == "Near Wall")
			{
				_driver.Evade("Wall");

			}
            if (evnt.Condition.Name == "Near Bot")
            {
                _driver.Evade("Bot");
            }
			if (evnt.Condition.Name == "No Target")
			{
				_scout.Sweep();
			}
			// else as replacement for nested ifs, will only fire if I have a valid target.
			else if (evnt.Condition.Name == "Ready to fire")
			{
				SetFire(1);
			}
		}
	}
}
