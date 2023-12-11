using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerFromFalling : MonoBehaviour
{
    public float startPositionY;
    public float maxFallDistance = 5.5f;
    public float fallDistance;

    public GameOverScreen GameOverScreen;

    private void Start()
    {       
        startPositionY = transform.position.y;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        startPositionY = transform.position.y;    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckFallDistance();
    }

    void CheckFallDistance()
    {   
        fallDistance = startPositionY - transform.position.y;

        if(fallDistance > maxFallDistance)
        {           
            gameObject.SetActive(false);
            GameOverScreen.DeathScreen();
            Time.timeScale = 0f;            
        }
    }
}
