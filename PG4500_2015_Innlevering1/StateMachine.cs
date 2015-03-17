using System;
using Robocode;

namespace Robot
{
	public class StateMachine
	{
		private States _currentState;
		private AdvancedRobot _robot;
		public enum States
		{
			IDLE,
			ENGAGE,
			SEARCH,
			EVADE
		}

		public StateMachine(AdvancedRobot robot, string state = "IDLE")
		{
			_robot = robot;
			SwitchState(state);
		}

		public string State
		{
			get
			{
				return _currentState.ToString();
			}

		}

		public void SwitchState(string state)
		{
			States previousState = _currentState != null ? _currentState : States.IDLE;
			switch (state)
			{
				default:
					_robot.Out.WriteLine("{0}\t## Invalid state invoked; returning to idle.", _robot.Time);
					goto case "IDLE";
				case "IDLE": //Idle
					_currentState = States.IDLE;
					break;
				case "ENGAGE": //Engage target
					_currentState = States.ENGAGE;
					break;
				case "SEARCH": //Searches for target
					_currentState = States.SEARCH;
					break;
				case "EVADE": //Evades incoming shots / charging bot
					_currentState = States.EVADE;
					break;
			}
			_robot.Out.WriteLine("{2}\t# Switched from: \"{0}\" to \"{1}\" ", previousState.ToString(), _currentState.ToString(), _robot.Time);
		}

	}
}
