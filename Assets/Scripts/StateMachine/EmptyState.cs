using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	public class EmptyState : State
	{
		public EmptyState(FiniteStateMachine machine, State previousState = null) : base(machine, previousState)
		{
			stateMachine = machine;

			this.previousState = previousState;
		}

		public override string GetStateName()
		{
			return "Empty";
		}
	}
}


