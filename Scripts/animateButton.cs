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
using UnityEngine;

public class animateButton : MonoBehaviour
{
	private enum GameState
	{
		Menu,
		Select
	}
	private GameState gameState;
	public Animator anim;
	public AnimationClip a;
	public AnimationClip b;
	public void Start()
	{
		gameState = GameState.Menu;
	}
	public void fucking_play()
	{
		switch (gameState)
		{
			case GameState.Menu:
				gameState = GameState.Select;
				anim.Play(a.name);
				break;
			case GameState.Select:
				break;
		}
	}
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			switch (gameState)
			{
				case GameState.Menu:
					break;
				case GameState.Select:
					gameState = GameState.Menu;
					anim.Play(b.name);
					break;
			}
		}
	}
}
