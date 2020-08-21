using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    private UIManager _uiManager;
    private Score _score;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _score = GameObject.Find("Player").GetComponent<Score>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (_score.GetScore() == 10)
            {
                SceneManager.LoadScene(2);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (_score.GetScore() == 10)
            {
                SceneManager.LoadScene(3);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (_score.GetScore() == 10)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        _uiManager.RestartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
