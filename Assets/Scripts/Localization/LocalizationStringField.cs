using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	[System.Serializable]
	public class LocalizationStringField
	{
		public LocalizationStringField(string español, string english)
		{
			this.español = español;
			this.english = english;
		}
		public LocalizationStringField()
		{

		}

		[SerializeField] private string español;
		[SerializeField] private string english;

		public string text
		{
			get
			{
				string text = "";

				switch (GameManager.Instance.CurrentLenguage)
				{
					case Lenguages.Spanish:
						text = español;
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


