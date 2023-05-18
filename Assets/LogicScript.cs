using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text txtScore;
    public GameObject gameOverScreen;
    public AudioSource gameLoop;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        score++;
        txtScore.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    void Start()
    {
        gameLoop.Play();
    }
}
