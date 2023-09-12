using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VelascoGames.Beethoven.World;
using TMPro;

namespace VelascoGames.Beethoven
{
	public class UIManager : GameSceneManager
	{
		[Title("Screen text")]
		[SerializeField] private TextMeshProUGUI areaNameTextField;
		[SerializeField] private TextMeshProUGUI roomNameTextField;

		[PropertySpace]
		[Title("Buttons")]
		[SerializeField] private GameObject[] buttons;


		protected override void InitGameFromSave()
		{
			foreach (var button in buttons)
				button.SetActive(false);
		}

		protected override void InitGameNewSave()
		{
		}

		public void SetUpRoomText(Room room)
		{
			areaNameTextField.text = room.AreaBelong.ZoneName;
			roomNameTextField.text = room.ZoneName;
		}

		public Button ActivateNewButton()
		{
			foreach(var button in buttons)
			{
				if (!button.activeSelf)
				{
					button.SetActive(true);

					return button.GetComponent<Button>();
				}
			}

			return null;
		}
	}
}

