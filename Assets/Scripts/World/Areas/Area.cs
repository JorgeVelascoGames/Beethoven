using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VelascoGames.Beethoven.World
{
	[CreateAssetMenu(menuName = "World/New Area")]
	public class Area : Location
	{
		[TitleGroup("Rooms")]
		[SerializeField] private Room entrance;

		[TitleGroup("Ints")]
		[TableList(ShowIndexLabels = true, AlwaysExpanded = true, DrawScrollView = false)]
		[SerializeField]private List<Room> rooms = new List<Room>();
		//Enemies for spawning


		#region Public properties

		public List<Room> Rooms => rooms;
		public Room Entrance => entrance;
		#endregion

#if(UNITY_EDITOR)
		[Button]
		public void GenerateNewRoom(string name, bool isEntrance)
		{
			//Crea la nueva room
			Room newRoom = CreateInstance<Room>();

			//Configurar la room
			newRoom.SetUpRoom(this);

			//Si es entrance
			if(isEntrance && entrance == null)
			{
				entrance = newRoom;
			}

			//Añadela a la lista
			rooms.Add(newRoom);

			//Crea el directorio para guardar el asset
			string outputPath = "Assets/World/" + this.name + "/" + this.name + "Rooms/" +name+ ".asset";

			// Crea el asset en la ruta especificada
			AssetDatabase.CreateAsset(newRoom, outputPath);

			// Refresca la base de datos de activos para que aparezca en el proyecto
			AssetDatabase.Refresh();
		}
#endif
	}
}


