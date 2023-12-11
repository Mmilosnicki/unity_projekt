using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningGame : MonoBehaviour
{
    public GameObject winningScreen;
    public GameObject statsScreen;
    public AudioSource WinSFX;
    public BananasManager bananasManager;
    public StatsManager stats;
    public Text totalBananasText;
    public Text finalTimeText;

    public void WinningScreen()
    {
        winningScreen.SetActive(true);
        statsScreen.SetActive(false);
        WinSFX.Play();
        totalBananasText.text = "Bananas collected: " + bananasManager.bananasCount.ToString() + "/5";
        finalTimeText.text = "Final Time: " + stats.minutes.ToString() + "min " + Mathf.Round(stats.seconds).ToString() + "sec"; ;
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
