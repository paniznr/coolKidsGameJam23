using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float timeLeft;
    [SerializeField] bool timerOn = false;
    [SerializeField] Text timerTxt;

    void Start()
    {
        timerOn = true;
    }

    void Update()
    {
        countdown();
    }

    void updateTimer(float currentTime)
    {
        if (currentTime == timeLeft)
        {
            currentTime += 1;
        }

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    void countdown()
    {
        subtractTime(Time.deltaTime);
    }

    public void subtractTime(float seconds)
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= seconds;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
}
