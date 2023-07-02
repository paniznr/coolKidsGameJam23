using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private TimerScript timer;

    [SerializeField] int numberOfPies;
    [SerializeField] Text pieText;
    //[SerializeField] GameObject gameOverScreen;

    public bool IsGameStarted => isGameStarted;
    private bool isGameStarted = false;
    public bool IsGameOver => isGameOver;
    private bool isGameOver = false;
    public bool IsGoalAchieved =>
        timer.TimeLeft >= 0 && numberOfPies == 0;

    private void Start()
    {
        timer = GameObject.FindAnyObjectByType<TimerScript>();
        printPies();

        // TODO: Remove this with a button check.
        isGameStarted = true;
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
}
