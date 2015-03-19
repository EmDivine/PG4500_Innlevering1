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
				_robot.Out.WriteLine("{0}\t# Switching state from {1} to {2}.", _robot.Time, _currentState, value);
				_currentState = value;
			}
		}

		public void SwitchState(States state)
		{
			States previousState = State != null ? State : States.IDLE;
			switch (state)
			{
				default:
					_robot.Out.WriteLine("{0}\t## Invalid state invoked; returning to idle.", _robot.Time);
					goto case States.IDLE;
				case States.IDLE: //Idle
					State = States.IDLE;
					break;
				case States.ENGAGE: //Engage target
					State = States.ENGAGE;
					break;
				case States.SEARCH: //Searches for target
					State = States.SEARCH;
					break;
				case States.EVADE: //Evades incoming shots / charging bot
					State = States.EVADE;
					break;
			}
			_robot.Out.WriteLine("{2}\t# Switched from: \"{0}\" to \"{1}\" ", previousState.ToString(), _currentState.ToString(), _robot.Time);
		}

	}
}
