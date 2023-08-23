using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	public class EnterRoomState : State
	{
		public EnterRoomState(FiniteStateMachine machine, State previousState = null) : base(machine, previousState)
		{
			stateMachine = machine;

			this.previousState = previousState;
		}

		public override string GetStateName()
		{
			return "Room state";
		}

		public override void StartState()
		{
		}
	}
}

