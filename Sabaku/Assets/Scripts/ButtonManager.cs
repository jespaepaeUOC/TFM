using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject mainMenu;
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

    public void ShowControls()
    {
        transform.parent.gameObject.SetActive(false);
        if(controlsMenu != null)
        {
            controlsMenu.SetActive(true);
        }
    }

    public void HideControls()
    {
        transform.parent.gameObject.SetActive(false);
        if(mainMenu != null)
        {
            mainMenu.SetActive(true);
        }
    }
}
