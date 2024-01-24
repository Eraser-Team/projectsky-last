using UnityEngine;
using UnityEngine.UI;

public class ESCsettings : MonoBehaviour
{
    private enum GameState
    {
        Settings,
        Game
//		SB
    }

    private GameState gameState;
	public GameObject settingsPanel;
	public MonoBehaviour lookScript;
//	public GameObject sbPanel;

    private void Start()
    {
        gameState = GameState.Game;
        Cursor.lockState = CursorLockMode.Confined;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (gameState)
            {
                case GameState.Settings:
				    Cursor.lockState = CursorLockMode.Locked;
                    settingsPanel.SetActive(false);
					lookScript.enabled = true;
                    gameState = GameState.Game;
                    break;
                case GameState.Game:
					Cursor.lockState = CursorLockMode.Confined;
                    settingsPanel.SetActive(true);
					lookScript.enabled = false;
                    gameState = GameState.Settings;
                    break;
            }
        }
    }
}
