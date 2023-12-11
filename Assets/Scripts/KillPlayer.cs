using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gameObject.SetActive(false);
            GameOverScreen.DeathScreen();
            Time.timeScale = 0f;
        }
    }
}
