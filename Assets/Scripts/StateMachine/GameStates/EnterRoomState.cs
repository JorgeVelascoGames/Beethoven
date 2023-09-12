using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven.World;

namespace VelascoGames.Beethoven
{   //Al entrar a una nueva room se carga este estado
	public class EnterRoomState : State
	{
		public EnterRoomState(FiniteStateMachine machine, State previousState = null) : base(machine, previousState)
		{
			stateMachine = machine;

			this.previousState = previousState;

			currentRoom = GameManager.Instance.PlayerManager.Navigation.CurrentRoom;
		}

		private Room currentRoom;

		public override string GetStateName()
		{
			return "Room state";
		}

		public override void StartState()
		{
			if (currentRoom.Enemie != null)
			{
				GameManager.Instance.GeneralStateMachine.StartNewState(new CombatState(GameManager.Instance.GeneralStateMachine));
			}



		}
	}
}

