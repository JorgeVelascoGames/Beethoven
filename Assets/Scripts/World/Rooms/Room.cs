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
		//Npc

		#region Public properties
		public Area AreaBelong => areaBelong;
		#endregion

		[Button]
		public void DelteRoom()
		{
			DestroyImmediate(this);
		}

		public void SetUpRoom(Area area)
		{
			areaBelong = area;
		}
	}
}

