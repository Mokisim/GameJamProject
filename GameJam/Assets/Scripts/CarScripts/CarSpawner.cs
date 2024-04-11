using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private TrafficLights _trafficLights;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    private void Start()
    {
       _coroutine = StartCoroutine(SpawnCars());
    }

    private void OnEnable()
    {
        _trafficLights.TrafficLightsOff += StopTraffic;
        _trafficLights.TrafficLightsOn += StartTraffic;
    }

    private void OnDisable()
    {
        _trafficLights.TrafficLightsOff -= StopTraffic;
        _trafficLights.TrafficLightsOn -= StartTraffic;
    }

    public void StopTraffic()
    {
        _audioSource.Play();

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void StartTraffic()
    {
        _audioSource.Stop();
        _coroutine = StartCoroutine(SpawnCars());
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
