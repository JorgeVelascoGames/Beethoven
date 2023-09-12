using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven.World;

namespace VelascoGames.Beethoven
{
	public class GraphicManager : GameSceneManager
	{
		private GameObject currentBackground;
		private GameObject currentCharacter;

		protected override void InitGameFromSave()
		{
		}

		protected override void InitGameNewSave()
		{
		}


		public void SetUpGraphics(GameObject currentRoom)
		{
			if(currentBackground != null)
				Destroy(currentBackground);

			if (currentRoom == null)
				return;

			currentBackground = currentRoom;
			Instantiate(currentBackground);
		}

		public void SpawnCharacter(GameObject character)
		{
			if(currentCharacter != null)
				Destroy(currentCharacter);

			if (character == null)
				return;

			currentCharacter = character;
			Instantiate(currentCharacter);
		}
	}
}


