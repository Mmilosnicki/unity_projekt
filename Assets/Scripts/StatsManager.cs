using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public int minutes;
    public float seconds;

    public Text timerText;

    void Update()
    {
        seconds += Time.deltaTime;
        timerText.text = "Time: " + minutes.ToString() + "min " + Mathf.Round(seconds).ToString() + "sec";

        if(seconds > 59)
        {
            minutes++;
            seconds = 0;
        }       
    }
}
