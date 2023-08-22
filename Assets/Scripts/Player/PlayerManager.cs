using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven.Player
{
	public class PlayerManager : GameSceneManager
	{
		[HideIf("navigation")] [SerializeField] private PlayerNavigation navigation;
		private List<PlayerSubManager> subManagers = new List<PlayerSubManager>();

		#region Public properties
		public PlayerNavigation Navigation => navigation;
		#endregion

		protected override void Awake()
		{
			foreach (var manager in GetComponentsInChildren<PlayerSubManager>())
				subManagers.Add(manager);

			base.Awake();
		}

		protected override void InitGameNewSave()
		{
			foreach (var manager in subManagers)
				manager.InitGameNewSave();
		}
		protected override void InitGameFromSave()
		{
			foreach (var manager in subManagers)
				manager.InitGameFromSave();
		}

		protected override void InitManager()
		{
			base.InitManager();
		}
	}
}


