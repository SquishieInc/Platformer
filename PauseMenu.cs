using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject pauseButton;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
		pauseButton.SetActive(false);
	}

    public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		pauseButton.SetActive(true);
	}

	public void LoadMenu(int menuToLoad)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(menuToLoad);
	}

    public void QuitGame()
	{
		Application.Quit();
	}
}
