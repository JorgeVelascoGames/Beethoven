using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace VelascoGames.Beethoven.CustomMenu
{
	public class SceneNavigationWindow : OdinEditorWindow
	{
		[MenuItem("Tools/Scene Navigator")]
		private static void OpenWindow()
		{
			GetWindow<SceneNavigationWindow>().Show();
		}

		[Button]
		private void GoToInitScene()
		{
			EditorSceneManager.OpenScene("Assets/Scenes/Init.unity");
		}

		[Button]
		private void GoToMainMenuScene()
		{
			EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
		}

		[Button]
		private void GoToMainGameScene()
		{
			EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity");
		}

		[Button]
		private void GoToLoadingScene()
		{
			EditorSceneManager.OpenScene("Assets/Scenes/LoadingScreen.unity");
		}
	}
}


