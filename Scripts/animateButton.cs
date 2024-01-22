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
