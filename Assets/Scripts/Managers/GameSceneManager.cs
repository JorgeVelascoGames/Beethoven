using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	public abstract class GameSceneManager : MonoBehaviour
	{
		protected virtual void Awake()
		{
			if(this is not RunManager)
			{
				RunManager.StartNewRun += InitGameNewSave;
				RunManager.LoadOngoingRun += InitGameFromSave;
			}

			GameManager.GameSetUp += InitManager;
			GameManager.Instance.ManagerSetUp(this);
		}

		protected virtual void InitManager()
		{

		}

		protected abstract void InitGameNewSave();
		protected abstract void InitGameFromSave();
	}
}

