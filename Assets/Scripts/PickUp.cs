using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform _theDestination;
    [SerializeField] private bool isPickable;

    private IEnumerator _coroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPickable == true)
        {
            Pick();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isPickable == false)
        {
            Throw();
        }
    }

    private void Pick()
    {
        this.transform.position = _theDestination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    private void Throw()
    {
        this.transform.parent = null;
        isPickable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPickable = true;
            _coroutine = WaitAndSetNotPickable(0.4f);
            StartCoroutine(_coroutine);
        }
    }

    IEnumerator WaitAndSetNotPickable(float _pickableTime)
    {
        yield return new WaitForSeconds(_pickableTime);
        isPickable = false;
    }
}
