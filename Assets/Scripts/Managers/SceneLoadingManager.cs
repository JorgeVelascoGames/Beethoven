using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using System;

namespace VelascoGames.Beethoven
{
	public class SceneLoadingManager : MonoBehaviour
	{
		public static Action<string> OnLoadScene;

		[SerializeField] private string mainMenuScene;
		[SerializeField] private string mainGameScene;
		[SerializeField] private string loadingScene;
		[SerializeField] private string initScene;

		[SerializeField] private float minLoadingTime = 2f;

		private AsyncOperation asyncOperation;

		public void GoToMainMenu()
		{
			StartCoroutine(LoadSceneAsync(mainMenuScene));
		}
		public void GoToMainGame()
		{
			StartCoroutine(LoadSceneAsync(mainGameScene));
		}

		public void GoToInitScene()
		{
			StartCoroutine(LoadSceneAsync(initScene));
		}

		public void GoToLoadingScene()
		{
			StartCoroutine(LoadSceneAsync(loadingScene));
		}

		private IEnumerator LoadSceneAsync(string sceneName)
		{
			// Load the loading scene first
			UnityEngine.SceneManagement.SceneManager.LoadScene(loadingScene.ToString());

			// Wait for one frame (this is needed because LoadScene is not instantaneous)
			yield return null;

			// Start loading the desired scene in the background
			asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

			// Don't allow the scene to activate until it's fully loaded
			asyncOperation.allowSceneActivation = false;

			float loadingStartTime = Time.time;

			// While the scene is still loading...
			while (!asyncOperation.isDone)
			{
				// If the loading progress reaches 0.9f (Unity's arbitrary number for scene loaded), the scene is ready
				if (asyncOperation.progress >= 0.9f)
				{
					// Check if the minimum loading time has passed
					if (Time.time - loadingStartTime >= minLoadingTime)
					{
						//A bit more of time...
						yield return new WaitForSeconds(0.3f);
						// Activate the scene
						asyncOperation.allowSceneActivation = true;
					}
				}

				// Yielding null means to wait for the next frame
				yield return null;
			}

			if (OnLoadScene != null)
				OnLoadScene(sceneName);
		}
	}
}

