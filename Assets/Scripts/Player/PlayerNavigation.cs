using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelascoGames.Beethoven.World;

namespace VelascoGames.Beethoven.Player
{
	public class PlayerNavigation : PlayerSubManager
	{
		private Location currentLocation;
		[SerializeField] private Location startingArea;

		#region Public properties
		[ShowInInspector] public Location CurrentRoom => currentLocation;
		 public Location StartingArea => startingArea;
		#endregion


		
		#region Load methods
		public override void InitGameFromSave()
		{
			Location newLocation = ES3.Load<Location>("currentLocation", SaveAndLoadManager.SAVE_BASIC_NAME);
			MoveToNewLocation(newLocation);
		}

		public override void InitGameNewSave()
		{
			MoveToNewLocation(startingArea);
		}
		#endregion


		/// <summary>
		/// Movemos al jugador a la nueva locación. Si es área, aparecerá en la entrada de la misma
		/// </summary>
		public void MoveToNewLocation(Location newLocation)
		{
			Room newRoom = null;

			if (newLocation is Room)
			{
				newRoom = (Room)newLocation;
			}
			else if (newLocation is Area)
			{
				Area area = (Area)newLocation;
				newRoom = area.Entrance;
			}
			else
			{
				Debug.LogError("The new Location is not a Room or an Area");
				return;
			}
			//Si no hay newRoom valida no ocurre nada
			if (newRoom == null)
				return;

			//Hacemos el cambio de estancia...


			currentLocation.PlayerLeaves();

			//....

			newRoom.PlayerArrives();

		    currentLocation = newRoom;

			ES3.Save("currentLocation", currentLocation, SaveAndLoadManager.SAVE_BASIC_NAME);
		}
	}
}


