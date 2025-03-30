using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void LoadMainMenuScene()
    {
        UnpauseGame();
        SceneManager.LoadScene("MainMenuScene");
    }
}
