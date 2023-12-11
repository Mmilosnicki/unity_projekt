using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;
    public AudioSource DeathSFX;
   
    public void DeathScreen()
    {
        gameOverScreen.SetActive(true);
        DeathSFX.Play();
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

    public void ExitButton()
    {
        Application.Quit();
    }
}
