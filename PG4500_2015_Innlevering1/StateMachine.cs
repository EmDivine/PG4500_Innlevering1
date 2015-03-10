using System;
using Robocode;

namespace Robot_support_classes
{
	public class StateMachine
	{
		States currentState = States.IDLE;
		AdvancedRobot robot;
		enum States
		{
			IDLE,
			ENGAGE,
			SEARCH,
			EVADE
		}

		//Gets no state input
		public StateMachine(AdvancedRobot robot)
		{
			this.robot = robot;
		}

		public string State
		{
			get
			{
				return currentState.ToString();
			}
			
		}

		public void SwitchState(string state)
		{
			States previousState = currentState;
			switch (state)
			{
				default:
					robot.Out.WriteLine("{0}\t## Invalid state invoked; returning to idle.",robot.Time);
					goto case "IDLE";
				case "IDLE": //Idle
					currentState = States.IDLE;
					break;
				case "ENGAGE": //Engage target
					currentState = States.ENGAGE;
					break;
				case "SEARCH": //Searches for target
					currentState = States.SEARCH;
					break;
				case "EVADE": //Evades incoming shots / charging bot
					currentState = States.EVADE;
					break;
			}
			robot.Out.WriteLine("{2}\t# Switched from: \"{0}\" to \"{1}\" ", previousState.ToString(), currentState.ToString(),  robot.Time);
		}

	}
}
