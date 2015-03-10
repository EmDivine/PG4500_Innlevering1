using System;
using Robocode;

namespace Robot_support_classes
{
	public class StateMachine
	{
		string currentState = "";
		AdvancedRobot rob;

		//Gets no state input
		public StateMachine()
		{
			SwitchState("IDLE");
		}

		public string State { get{ return currentState;}private set;}

		public void SwitchState (string state)
		{
			switch (state)
			{
				case "IDLE": //Idle
					currentState = "IDLE";
					break;
				case "ENGAGE": //Engage target
					currentState = "ENGAGE";
					break;
				case "SEARCH": //Searches for target
					currentState = "SEARCH";
					break;
				case "EVADE": //Evades incoming shots / charging bot
					currentState = "EVADE";
					break;
				default:
					currentState = "IDLE";
					break;
			}
		}

	}
}
