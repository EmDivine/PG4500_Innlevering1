using System;
using Robocode;

namespace Robot_support_classes
{
	public class StateMachine
	{
		States currentState = States.IDLE;
		AdvancedRobot rob;
		enum States
		{
			IDLE,
			ENGAGE,
			SEARCH,
			EVADE
		}

		//Gets no state input
		public StateMachine(AdvancedRobot rob)
		{
			this.rob = rob;
		}

		public States State
		{
			get
			{
				return currentState;
			}
			private set;
		}

		public void SwitchState(States state)
		{
			switch (state)
			{
				default:
				case States.IDLE: //Idle

					break;
				case States.ENGAGE: //Engage target

					break;
				case States.SEARCH: //Searches for target

					break;
				case States.EVADE: //Evades incoming shots / charging bot

					break;
			}
		}

	}
}
