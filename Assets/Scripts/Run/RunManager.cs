using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven.World;

namespace VelascoGames.Beethoven
{
	public class RunManager : GameSceneManager
	{
		public static Action StartNewRun;
		public static Action LoadOngoingRun;

		#region Public properties
		#endregion

		protected override void InitManager()
		{
			CheckRunSavingState();
		}

		private void CheckRunSavingState()
		{
			if (GameManager.Instance.SaveAndLoadManager.IsRunStarted())
			{
				if (LoadOngoingRun != null)
					LoadOngoingRun();
			}
			else
			{
				if (StartNewRun != null)
					StartNewRun();
			}
	    }


		#region Unnecessary
		protected override void InitGameFromSave()
		{
		}

		protected override void InitGameNewSave()
		{
		}
		#endregion
	}
}


