using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven;

namespace VelascoGames.StateMachine
{
	public class MainMenuState : State
	{
		public MainMenuState(FiniteStateMachine machine, State previousState = null) : base(machine, previousState)
		{
			stateMachine = machine;

			this.previousState = previousState;
		}

		public override void StartState()
		{
			if (previousState is AskForOverrideGame)
				return;

			GameManager.Instance.SceneManager.GoToMainMenu();
		}

		public override string GetStateName()
		{
			return "Main Menu State";
		}

		/// <summary>
		/// Borra la anterior aventura, empieza una nueva
		/// </summary>
		public override void OnClickStartButton()
		{
			if (ES3.FileExists(SaveAndLoadManager.SAVE_BASIC_NAME))
			{
				if (GameManager.Instance.SaveAndLoadManager.IsRunStarted())
				{
					GameManager.Instance.GeneralStateMachine.StartNewState(new AskForOverrideGame(GameManager.Instance.GeneralStateMachine, this));

					return;
				}
			}

			GameManager.Instance.SaveAndLoadManager.CreateNewSave();
			GameManager.Instance.SceneManager.GoToMainGame();
		}

		/// <summary>
		/// Continua con la aventura
		/// </summary>
		public override void OnClickNextButton()
		{
		}
		public override void OnClickBackButton()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
		public override void OnClickOptionsButton()
		{
		}

		/// <summary>
		/// Esto maneja el menú en el que preguntamos al jugador si quiere sobreescribir partida
		/// </summary>
		private class AskForOverrideGame : State
		{
			private GameObject askMenu;

			public AskForOverrideGame(FiniteStateMachine machine, State previousState = null) : base(machine, previousState)
			{
				stateMachine = machine;

				this.previousState = previousState;

				askMenu = GameObject.Find("OverrideAsk");

				askMenu.SetActive(true);
			}

			public override string GetStateName()
			{
				return "Ask for override game";
			}

			public override void OnClickStartButton()
			{
				GameManager.Instance.SaveAndLoadManager.CreateNewSave();
				GameManager.Instance.SceneManager.GoToMainGame();
			}

			public override void OnClickBackButton()
			{
				askMenu.SetActive(false);

				GameManager.Instance.GeneralStateMachine.StartNewState(new MainMenuState(GameManager.Instance.GeneralStateMachine, this));
			}

		}
		
	}
}
