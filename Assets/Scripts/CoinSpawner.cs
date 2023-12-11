using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _bronze;
    [SerializeField] private Coin _silver;
    [SerializeField] private Coin _gold;

    private Transform[] _spawnPoints;
    private Coin[] _coins;
    private float _cooldown = 2f;

    private void Start()
    {
        _coins = new[] { _bronze, _silver, _gold };
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);

        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        var cooldown = new WaitForSeconds(_cooldown);
        bool isWorking = true;
        
        while (isWorking)
        {
            yield return cooldown;
            
            Coin coin = _coins[Random.Range(0, _coins.Length)];
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
           
            if (spawnPoint.childCount == 0)
                Instantiate(coin, spawnPoint);
        }
    }
}
