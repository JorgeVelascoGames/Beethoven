using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelascoGames.Beethoven.Graphics
{
	public class GraphicColocation : MonoBehaviour
	{
		[SerializeField] private Vector3 position;
		[SerializeField] private Vector3 scale;
		private void Start()
		{
			transform.position = position;
			transform.localScale = scale;
		}

		[Button]
		public void SavePositionAndScale()
		{
			position = transform.position;
			scale = transform.localScale;
		}
	}
}

