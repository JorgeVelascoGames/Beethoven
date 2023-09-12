using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven.Player;
using VelascoGames.StateMachine;

namespace VelascoGames.Beethoven
{

	public class GameManager : MonoBehaviour
	{
		[SerializeField] private Lenguages currentLenguage;
		public static GameManager Instance => instance;
		private static GameManager instance;

		public static Action GameSetUp;

		private FiniteStateMachine generalStateMachine;

		#region Sub managers
		[SerializeField] [HideIf("gameSceneManager")] private SceneLoadingManager gameSceneManager;
		[SerializeField] [HideIf("corutineManager")] private CorutineManager corutineManager;
		[SerializeField] [HideIf("globalConfiguration")] private GlobalConfiguration globalConfiguration;
		[SerializeField] [HideIf("objectReferences")] private ReferenceManager objectReferences;
		[SerializeField] [HideIf("saveManager")] private SaveAndLoadManager saveManager;
		private PlayerManager playerManager;
		private RunManager runManager;
		private UIManager uiManager;
		private GraphicManager graphicManager;
		#endregion

		#region Public properties
		public FiniteStateMachine GeneralStateMachine => generalStateMachine;
		public SceneLoadingManager SceneManager => gameSceneManager;
		public CorutineManager CorutineManager => corutineManager;
		public GlobalConfiguration Configuration => globalConfiguration;
		public ReferenceManager ObjectReferences => objectReferences;
		public PlayerManager PlayerManager => playerManager;
		public RunManager RunManager => runManager;
		public SaveAndLoadManager SaveAndLoadManager => saveManager;
		public UIManager UIManager => uiManager;
		public GraphicManager GraphicManager => graphicManager;
		public Lenguages CurrentLenguage => currentLenguage;
		#endregion

		#region Unity methods
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}

			generalStateMachine = new FiniteStateMachine(new EmptyState(generalStateMachine));
			//Actions
			ButtonOptions.OnClickStart += generalStateMachine.OnClickStartButton;
			ButtonOptions.OnClickNext += generalStateMachine.OnClickNextButton;
			ButtonOptions.OnClickBack += generalStateMachine.OnClickBackButton;
			ButtonOptions.OnClickOptions += generalStateMachine.OnClickOptionsButton;

			//Dont destroy on load
			DontDestroyOnLoad(gameObject);

			generalStateMachine.StartNewState(new MainMenuState(generalStateMachine));
		}

		private void Update()
		{
			if (generalStateMachine != null)
				generalStateMachine.Update();
		}
		private void FixedUpdate()
		{
			if (generalStateMachine != null)
				generalStateMachine.FixedUpdate();
		}
		private void LateUpdate()
		{
			if (generalStateMachine != null)
				generalStateMachine.LateUpdate();
		}
		#endregion

		#region Game Managers Setup

		public void ManagerSetUp(GameSceneManager newManager)
		{
			if(newManager is UIManager)
			{
				uiManager = (UIManager)newManager;
			}
			else if(newManager is PlayerManager)
			{
				playerManager = (PlayerManager)newManager;
			}
			else if(newManager is RunManager)
			{
				runManager = (RunManager)newManager;
			}
			else if(newManager is GraphicManager)
			{
				graphicManager = (GraphicManager)newManager;
			}

			//Para prevenir problemas de referencias al cargar el juego, se asegura de que todos los managers estén configurados
			if(uiManager != null &&
				playerManager != null &&
				runManager != null &&
				graphicManager != null)
			{
				if (GameSetUp != null)
					GameSetUp(); //Aquí avisamos de que el Game Manager ya está cargado debidamente
			}
		}
		#endregion

		/// <summary>
		/// Sets up the lenguage of the game
		/// </summary>
		public void SetUpLenguage(Lenguages newLenguage)
		{
			currentLenguage = newLenguage;
		}
	}

}

public enum Lenguages
{
	Spanish,
	English
}
