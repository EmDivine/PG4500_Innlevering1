using System;
using Robocode;

namespace Robot
{
	public enum States
	{
		IDLE,
		ENGAGE,
		SEARCH,
		EVADE
	}

	public class StateMachine
	{
		private States _currentState;
		private AdvancedRobot _robot;

		public StateMachine(AdvancedRobot robot, States state = States.IDLE)
		{
			_robot = robot;
			State = state;
		}

		public States State
		{
			get
			{
				return _currentState;
			}
			set
			{
				if (value != _currentState)
				{
					_robot.Out.WriteLine("{0}\t# Switching state from {1} to {2}.", _robot.Time, _currentState, value);
					_currentState = value;
				}
			}
		}
	}
}
