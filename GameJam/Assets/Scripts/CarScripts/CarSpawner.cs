using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {
        var wait = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        var car = _pool.GetObject();

        car.gameObject.SetActive(true);
        car.transform.position = spawnPoint;
    }
}
