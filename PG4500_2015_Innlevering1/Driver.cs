using Robocode;
using PG4500_2015_Innlevering1;
using System;

namespace Robot
{
	class Driver
	{
		private malseb_horjan_Draziel _robot;
		public Driver(malseb_horjan_Draziel robot)
		{
			_robot = robot;
		}

		public void Drive()
		{
			_robot.SetAhead(200);
			_robot.Execute();
		}

		public void Evade()
		{
			//_robot.Out.WriteLine("{0}\t# Heading towards wall. Turning around to avoid collision.", _robot.Time);
			//// If robot is close to a wall, it stops, turns around (not smart, should be fixed), sets new couse (straight ahead) and 
			//_robot.SetStop(true);
			//_robot.SetTurnRight(180);
			//long stopTime = _robot.Time;
			//_robot.Out.WriteLine("{0}\t# Timer set.", _robot.Time);
			//_robot.WaitFor(new TurnCompleteCondition(_robot));
			//_robot.SetResume();
			//_robot.WaitFor(new Condition("Turn timer", 1, (b) => { return stopTime + 50 < _robot.Time; }));
			//_robot.Execute();
		}

		public bool NearWall
		{
			get
			{
				return (((Math.Min(_robot.X, _robot.BattleFieldWidth - _robot.X) < (_robot.Height + 30)) || (Math.Min(_robot.Y, _robot.BattleFieldHeight - _robot.Y) < (_robot.Height + 30))));
			}
		}





	}



}
