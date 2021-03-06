﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicGarbage : MonoBehaviour
{
    [SerializeField] private Score _playerScore;

    public AudioSource correctCan;
    public AudioSource wrongCan;
    public AudioSource[] pick;

    private UIManager _uiManager;

    private void Start()
    {
        _playerScore = GameObject.Find("Player").GetComponent<Score>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var randomAudio = pick[Random.Range(0, pick.Length - 1)];

        if (collision.gameObject.CompareTag("Organic_can"))
        {
            _playerScore.AddScore(1);
            correctCan.Play();
            wrongCan.Stop();
            randomAudio.Stop();
            Debug.Log("Correct Can, you got 1 point");
            Destroy(this.gameObject, 0.5f);
        }

        if (collision.gameObject.CompareTag("Plastic_can") || collision.gameObject.CompareTag("Paper_can") || collision.gameObject.CompareTag("Glass_can") || collision.gameObject.CompareTag("Metal_can"))
        {
            _playerScore.SubScore(1);
            correctCan.Stop();
            wrongCan.Play();
            randomAudio.Stop();
            Debug.Log("Wrong can, you lose a point");
            Destroy(this.gameObject, 0.5f);
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collision detected");
            correctCan.Stop();
            wrongCan.Stop();
            randomAudio.Play();
        }
    }
}
