using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private AudioSource _stepsSource;

    private Animator _animator;



    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        _stepsSource = this.gameObject.GetComponent<AudioSource>();
        _animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            _stepsSource.Play();
        }

        _animator.SetFloat("speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        transform.Translate(new Vector3(1, 0, 0) * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(new Vector3(0, 1, 0) * verticalInput * _speed * Time.deltaTime);

        //clamp x de -8.50 até 8.50
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), transform.position.y, 0);

        //clamp y de -4.62 até 4.62
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.62f, 4.62f), 0);
    }
} 
