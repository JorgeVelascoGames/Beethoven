using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	public class SaveAndLoadManager : MonoBehaviour
	{
		public const string SAVE_BASIC_NAME = "SaveData";
		public const string BOOL_RUN_STARTED = "runStarted";

		public void CreateNewSave()
		{
			DeleteSave();
			ES3.Save(BOOL_RUN_STARTED, false, SAVE_BASIC_NAME);
		}

		public void DeleteSave()
		{
			ES3.DeleteFile(SAVE_BASIC_NAME);
		}

		public bool IsRunStarted()
		{
			bool temp = ES3.Load(BOOL_RUN_STARTED, false);

			return temp;
		}
	}
}

