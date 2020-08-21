using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _garbage;

    private PlayerMovement _player;
    private IEnumerator _garbageRoutine; 

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        int _randomGarbage = Random.Range(0, 4);

        float randomX = Random.Range(-8.5f, 8.5f);
        float randomY = Random.Range(-4.62f, 1.6f);
        Vector3 positionToSpawn = new Vector3(randomX, randomY, 0);

        Instantiate(_garbage[_randomGarbage], positionToSpawn, Quaternion.identity);

        _garbageRoutine = SpawnGarbageRoutine(5.0f);
        StartCoroutine(_garbageRoutine);
    }

    IEnumerator SpawnGarbageRoutine(float _spawnTime)
    {
        yield return new WaitForSeconds(_spawnTime);

        while (_player != null)
        {
            int _randomGarbage = Random.Range(0, 4);

            float randomX = Random.Range(-8.5f, 8.5f);
            float randomY = Random.Range(-4.62f, 1.6f);
            Vector3 positionToSpawn = new Vector3(randomX, randomY, 0);

            Instantiate(_garbage[_randomGarbage], positionToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
