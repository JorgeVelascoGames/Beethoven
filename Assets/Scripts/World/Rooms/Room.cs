using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven.World
{
	public class Room : Location
	{
		private Area areaBelong;
		//Location string
		//Enemigo/Jefe
		//Tesoro
		[TitleGroup("Room elements", "All the elements that can be found in the room")]
		[SerializeField] private GameObject roomBrackground;
		[SerializeField] private GameObject enemie;
		[SerializeField] private GameObject npc;
		[SerializeField] [TextArea] private string roomDescription;

		#region Public properties
		public Area AreaBelong => areaBelong;
		public GameObject RoomBackground => roomBrackground;
		public string RoomDescription => roomDescription;

		public GameObject Enemie => enemie;
		public GameObject NPC => npc;
		#endregion


		#region Room object methods
		[PropertySpace]
		[Button]
		public void DelteRoom()
		{
			DestroyImmediate(this);
		}

		public void SetUpRoom(Area area)
		{
			areaBelong = area;
		}
		#endregion
	}
}

