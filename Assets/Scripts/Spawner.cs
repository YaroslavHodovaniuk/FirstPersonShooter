using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0;
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                int EnemyNumber = Random.Range(0, _enemyPrefab.Length);

                Instantiate(_enemyPrefab[EnemyNumber], _spawnPoints[spawnPointNumber].position, Quaternion.identity);

                if (_secondsBetweenSpawn > 2)
                    _secondsBetweenSpawn -= 0.5f;
        }
    }
}
