using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _timeText;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameObject _instructionsPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private Animator _waveAnimator; 

    private bool _canPass;
    private bool _isPaused;
    private float _timeStart = 60;


    // Start is called before the first frame update
    void Start()
    {
        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1)))
        {
            _waveAnimator = GameObject.Find("Wave_Panel").GetComponent<Animator>();
            _pausePanel.SetActive(false);
            _startPanel.SetActive(true);
            _instructionsPanel.SetActive(false);
            _gameOverPanel.SetActive(false);
            _canPass = true;

            _scoreText.text = "Score: " + 0;
            _waveAnimator.GetBool("open");
            _waveAnimator.SetBool("open", true);
            _timeText.text = _timeStart.ToString();

            Time.timeScale = 0;
        }

        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2)))
        {
            _waveAnimator = GameObject.Find("Wave_Panel").GetComponent<Animator>();
            _pausePanel.SetActive(false);
            _gameOverPanel.SetActive(false);
            _canPass = true;

            _scoreText.text = "Score: " + 0;
            _waveAnimator.GetBool("open");
            _waveAnimator.SetBool("open", true);
            _timeText.text = _timeStart.ToString();

            Time.timeScale = 0;
        }

        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3)))
        {
            _waveAnimator = GameObject.Find("Wave_Panel").GetComponent<Animator>();
            _pausePanel.SetActive(false);
            _gameOverPanel.SetActive(false);
            _canPass = true;

            _scoreText.text = "Score: " + 0;
            _waveAnimator.GetBool("open");
            _waveAnimator.SetBool("open", true);
            _timeText.text = _timeStart.ToString();

            Time.timeScale = 0;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && _canPass == true)
        {
            _pausePanel.SetActive(false);
            _startPanel.SetActive(false);
            _instructionsPanel.SetActive(true);
            _gameOverPanel.SetActive(false);
            _canPass = true;
            Time.timeScale = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && _canPass == true)
        {
            _pausePanel.SetActive(false);
            _startPanel.SetActive(false);
            _instructionsPanel.SetActive(false);
            _gameOverPanel.SetActive(false);
            _canPass = false;
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                _isPaused = true;
                _pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _isPaused = false;
                _pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            
        }

        _timeStart = _timeStart - Time.deltaTime;
        _timeText.text = Mathf.Round(_timeStart).ToString();

        if (_timeStart <= 0 && _isPaused == false)
        {
            _pausePanel.SetActive(false);
            _startPanel.SetActive(false);
            _instructionsPanel.SetActive(false);
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OpenWavePanel()
    {
        bool isOpen = _waveAnimator.GetBool("open");

        _waveAnimator.SetBool("open", isOpen);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void GameOver()
    {
        _pausePanel.SetActive(false);
        _startPanel.SetActive(false);
        _instructionsPanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        _pausePanel.SetActive(false);
        _startPanel.SetActive(false);
        _instructionsPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _canPass = false;
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        _isPaused = false;
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
