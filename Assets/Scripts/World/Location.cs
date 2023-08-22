using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven.World
{
	public abstract class Location : ScriptableObject
	{
		[SerializeField]protected LocalizationStringField zoneName = new LocalizationStringField();

		[SerializeField]
		protected Location[] conections;

		#region Public properties
		public string ZoneName => zoneName.text;
		public Location[] Conections => conections;
		#endregion

		public void PlayerArrives()
		{

		}

		public void PlayerLeaves()
		{

		}
	}

}

