using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField] int numberOfPies;
    [SerializeField] Text pieText;
    //[SerializeField] GameObject gameOverScreen;

    private void Start()
    {
        printPies();
    }

    public void printPies()
    {
        pieText.text = "Pies: " + numberOfPies.ToString();
    }

    [ContextMenu("Decrease pies")]
    public void decreasePies(int pieQuantity)
    {
        numberOfPies -= pieQuantity;
        printPies();
    }

    public void restartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        //gameOverScreen.SetActive(true);
    }
}
