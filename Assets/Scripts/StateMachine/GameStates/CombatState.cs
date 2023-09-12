using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven.World;

namespace VelascoGames.Beethoven
{
	public class CombatState : State
	{
		public CombatState(FiniteStateMachine machine, State previousState = null) : base(machine, previousState)
		{
			stateMachine = machine;

			this.previousState = previousState;

			currentRoom = GameManager.Instance.PlayerManager.Navigation.CurrentRoom;
		}

		private Room currentRoom;


		public override string GetStateName()
		{
			return "Combat state";
		}

		public override string GetHelpText()
		{
			return "";
		}
	}
}


