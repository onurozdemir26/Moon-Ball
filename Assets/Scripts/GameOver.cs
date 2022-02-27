using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Score.scoreValue = 0;
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
        Score.scoreValue = 0;
    }
}
