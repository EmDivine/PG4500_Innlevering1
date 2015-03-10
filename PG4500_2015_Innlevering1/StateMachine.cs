using System;
using Robocode;

namespace Robot_support_classes
{
	public class StateMachine
	{
		string currentState = "";
		AdvancedRobot rob;
		enum States {IDLE = 1, ENGAGE, SEARCH, EVADE}

		//Gets no state input
		public StateMachine(AdvancedRobot rob)
		{
			this.rob = rob;
			SwitchState("IDLE");
		}

		public string State { get{ return currentState;}private set;}

		public void SwitchState (string state)
		{
			switch (state)
			{
				case "IDLE": //Idle
					currentState = States.IDLE.ToString();
					break;
				case "ENGAGE": //Engage target
					currentState = States.ENGAGE.ToString();
					break;
				case "SEARCH": //Searches for target
					currentState = States.SEARCH.ToString();
					break;
				case "EVADE": //Evades incoming shots / charging bot
					currentState = States.EVADE.ToString();
					break;
				default:
					currentState = States.IDLE.ToString();
					break;
			}
		}

	}
}
