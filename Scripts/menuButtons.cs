using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtons : MonoBehaviour
{
	public GameObject LoadingScreen;
	
	public void LoadScene(int sceneId)
	{
		StartCoroutine(LoadSceneAsync(sceneId));
	}
	
	IEnumerator LoadSceneAsync(int sceneId)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
		LoadingScreen.SetActive(true);
		while (!operation.isDone)
		{
			float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
			yield return null;
		}
	}

	public void OnExitHandler()
	{
		Application.Quit();
	}
}
