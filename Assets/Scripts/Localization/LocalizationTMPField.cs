using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven
{
	[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
	public class LocalizationTMPField : MonoBehaviour
	{
		[SerializeField] private string español;
		[SerializeField] private string ingles;

		IEnumerator Start()
		{
			yield return new WaitForSeconds(0.3f);

			string temp = "";

			switch (GameManager.Instance.CurrentLenguage)
			{
				case Lenguages.Spanish:
					temp = español;
						break;
				case Lenguages.English:
					temp = ingles;
					break;
			}


			GetComponent<TMPro.TextMeshProUGUI>().text = temp;
		}
	}
}

