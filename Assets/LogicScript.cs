using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField] float timeLeft;
    [SerializeField] bool timerOn = true;
    [SerializeField] Text timerTxt;

    [SerializeField] int numberOfPies;
    [SerializeField] Text pieText;
    //[SerializeField] GameObject gameOverScreen;

    public bool IsGameStarted => isGameStarted;
    private bool isGameStarted = false;
    public bool IsGameOver => isGameOver;
    private bool isGameOver = false;
    public bool IsGoalAchieved =>
        timeLeft >= 0 && numberOfPies == 0;

    private void Start()
    {
        printPies();

        // TODO: Remove this with a button check.
        isGameStarted = true;
    }

    private void Update()
    {
        timerOn = !isGameOver;
        countdown();
    }

    public void printPies()
    {
        pieText.text = "Pies: " + numberOfPies.ToString();
    }

    [ContextMenu("Decrease pies")]
    public void decreasePies(int pieQuantity)
    {
        numberOfPies -= pieQuantity;
        if (numberOfPies <= 0)
        {
            numberOfPies = 0;
            printPies();
            gameOver();
        }
        else
        {
            printPies();
        }
    }

    public void startGame()
    {
        isGameStarted = true;

        // Load/disable scene?
    }

    public void restartGame()
    {
        // Perhaps just call startGame()?

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;
        //gameOverScreen.SetActive(isGameOver);
    }

    // Timer stuff.

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
                gameOver();
            }
        }
    }
}
