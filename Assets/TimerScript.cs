using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerTxt;

    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        countdown();
    }

    void updateTimer(float currentTime)
    {
        if (currentTime == TimeLeft) { 
            currentTime += 1;
        }

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
    
    void countdown()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    public void subtractTime(int seconds)
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= seconds;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }
}
