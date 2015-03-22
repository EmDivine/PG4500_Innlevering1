using Robocode;
using Draziel;
using Draziel.Coordinates;
using System;

namespace PG4500_2015_Innlevering1
{
	public class malseb_horjan_Draziel : AdvancedRobot
	{
		private Gunner _gunner;
		private Scout _scout;
		private Driver _driver;

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
			AddCustomEvent(new Condition("Near wall", 19, (ICanWriteAnythingHere) => _driver.NearWall));
			AddCustomEvent(new Condition("No target", 19, (b) => !_scout.HaveTarget));
			AddCustomEvent(new Condition("Ready to fire", 50, (b) => Math.Abs(GunTurnRemaining) < 2));
			AddCustomEvent(new Condition("Turn complete", 50, (b) => new TurnCompleteCondition(this).Test()));
			AddCustomEvent(new Condition("Has Stopped", 19, (b) => Velocity <= 1));
            //to be implemented
			// AddCustomEvent(new Condition("Near Bot", 20, (b) => _driver.NearBot));

			GameLoop();
		}

		public void GameLoop()
		{
			while (true)
			{
				_driver.Drive();
				Execute();
			}
		}

		public override void OnScannedRobot(ScannedRobotEvent e)
		{
			_scout.OnScannedRobot(e);
			_gunner.onScannedRobot(_scout.TargetPosition, new Polar2(e.Velocity, -e.Heading + 90));
		}

		public override void OnRobotDeath(RobotDeathEvent e)
		{
			_scout.OnRobotDeath(e.Name);
		}

		public override void OnDeath(DeathEvent e)
		{
			Out.WriteLine("{0}\t# ALL SYSTEMS DOWN! I REPEAT, ALL SYSTE...", Time);
		}

		public override void OnHitByBullet(HitByBulletEvent evnt)
		{
			Out.WriteLine("{0}\t# OW! {1} just shot me!", Time, evnt.Name);
		}

		public override void OnCustomEvent(CustomEvent evnt)
		{
			if (evnt.Condition.Name == "Near wall")
			{
				_driver.Evade("Wall");

			}
			//to be implemented
			if (evnt.Condition.Name == "Near Bot")
			{
				_driver.Evade("Bot");
			}
			if (evnt.Condition.Name == "No target")
			{
				_scout.Sweep();
			}
			if (evnt.Condition.Name == "Ready to fire")
			{
				if (_scout.HaveTarget)
				{
					SetFire(1);
				}
			}
			if (evnt.Condition.Name == "Turn complete")
			{
				MaxVelocity = 8;
			}
            if (evnt.Condition.Name == "Has Stopped")
            {
                SetTurnRight(180);
            }
		}
	}
}
