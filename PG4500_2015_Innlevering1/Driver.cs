using Robocode;
using System;

namespace Robot
{
	class Driver
	{
		private AdvancedRobot _robot;
		public Driver(AdvancedRobot robot)
		{
			_robot = robot;
		}

		public void Evade()
		{
			while (true)
			{
				if (NearWall)
				{
					_robot.Out.WriteLine("{0}\t# Heading towards wall. Turning around to avoid collision.", _robot.Time);
					// If robot is close to a wall, it stops, turns around (not smart, should be fixed), sets new couse (straight ahead) and 
					_robot.SetStop(true);
					_robot.SetTurnRight(180);
					long stopTime = _robot.Time;
					_robot.WaitFor(new TurnCompleteCondition(_robot));
					_robot.SetResume();
					_robot.WaitFor(new Condition((b) => { return stopTime + 50 < _robot.Time; }));
					_robot.Execute();
				}
				
			}
		}

		public bool NearWall
		{
			get { return (((Math.Min(_robot.X, _robot.BattleFieldWidth - _robot.X) < (_robot.Height + 30)) || (Math.Min(_robot.Y, _robot.BattleFieldHeight - _robot.Y) < (_robot.Height + 30))); }
			
		}
		



	}



}
