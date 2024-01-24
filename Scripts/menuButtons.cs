/*
 * Project Sky - da
 * Copyright (C) 2024 Eraser-Team
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
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
