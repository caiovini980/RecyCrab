using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(_player.gameObject, 1f);
            _uiManager.GameOver();
        }
    }
}
