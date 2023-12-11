using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public JumpKing player;

    public void pausedScreen()
    {
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeButton()
    {
        pauseMenuScreen.SetActive(false);
        player.BGMusic.Play();
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
