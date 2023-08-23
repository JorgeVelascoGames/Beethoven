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
		[Title("Screen components")]
		[SerializeField] private Image backgroundImage;
		[SerializeField] private TextMeshProUGUI areaNameTextField;
		[SerializeField] private TextMeshProUGUI roomNameTextField;


		protected override void InitGameFromSave()
		{
		}

		protected override void InitGameNewSave()
		{
		}

		public void SetUpRoom(Room room)
		{
			backgroundImage.sprite = room.RoomBackground;
			areaNameTextField.text = room.AreaBelong.ZoneName;
			roomNameTextField.text = room.ZoneName;
		}
	}
}

