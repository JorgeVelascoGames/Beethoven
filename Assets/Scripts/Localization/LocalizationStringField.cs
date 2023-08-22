using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	[System.Serializable]
	public class LocalizationStringField
	{
		public LocalizationStringField(string espa�ol, string english)
		{
			this.espa�ol = espa�ol;
			this.english = english;
		}
		public LocalizationStringField()
		{

		}

		[SerializeField] private string espa�ol;
		[SerializeField] private string english;

		public string text
		{
			get
			{
				string text = "";

				switch (GameManager.Instance.CurrentLenguage)
				{
					case Lenguages.Spanish:
						text = espa�ol;
						break;
					case Lenguages.English:
						text = english;
						break;
				}
	
			return text;
			}
		}
	}

}


