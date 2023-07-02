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
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gameStartScreen;

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
        isGameStarted = false;
    }

    private void Update()
    {
        timerOn = isGameStarted && !isGameOver;
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
        gameStartScreen.SetActive(!isGameStarted);
        // Load/disable scene?
        // ??
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void restartGame()
    {
        // Perhaps just call startGame()?
        // ??
        Debug.Log("start game runs");
        isGameOver = false;
        isGameStarted = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //startGame();
        // ???
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;

        // TODO: Edit as needed.
        gameOverScreen.SetActive(isGameOver);
    }

    // Timer stuff.

    void updateTimer(float currentTime)
    {
        if (currentTime == timeLeft)
        {
            currentTime += 1;
        }

        float minutes = Mathf.FloorToInt(currentTime / 60);
        if (minutes <= 0)
        {
            minutes = 0;
        }
        float seconds = Mathf.FloorToInt(currentTime % 60);
        if (seconds <= 0)
        {
            seconds = 0;
        }

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
