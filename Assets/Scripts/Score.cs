using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _score = 0;
    }

    public void AddScore(int points)
    {
        _score = _score + points;
        _uiManager.UpdateScore(_score);
    }

    public void SubScore(int points)
    {
        _score = _score - points;

        if (_score < 0)
        {
            _score = 0;
        }

        _uiManager.UpdateScore(_score);
    }
    public int GetScore()
    {
        return _score;
    }

}
