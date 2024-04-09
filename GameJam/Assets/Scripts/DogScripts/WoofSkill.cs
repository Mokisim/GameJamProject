using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoofSkill : MonoBehaviour
{
    public event Action<float, float> WaveCreated;

    [SerializeField] private Dog _dog;
    [SerializeField] private DogsWave _wavePrefab;
    [SerializeField] private int _wavesCount;
    [SerializeField] private float _waveSpeed;
    [SerializeField] private int _woofCount;
    [SerializeField] private float _waveSize;
    [SerializeField] private float _waveSizeDecrease;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private float _waitTime = 0.5f;
    private float _cooldown = 6;
    private float _nextActionTime;

    private void Start()
    {
        _coroutine = StartCoroutine(Woof());
        _wait = new WaitForSeconds(_waitTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_woofCount > 0 && _nextActionTime <= Time.time)
            {
                _coroutine = StartCoroutine(Woof());
                _woofCount--;
            }
            else
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
        }
    }

    private IEnumerator Woof()
    {
        _nextActionTime = Time.time + _cooldown;

        for (int i = 0; i < _wavesCount; i++)
        {
            float newWaveSize = _waveSize - _waveSizeDecrease * i;

            if (i == 0)
            {
                CreateSoundWaves(_waveSize, _waveSpeed);
            }
            else
            {
                CreateSoundWaves(newWaveSize, _waveSpeed);
            }

            yield return _wait;
        }
    }

    private void CreateSoundWaves(float size, float speed)
    {
        DogsWave wave = Instantiate(_wavePrefab, transform.position, transform.rotation);
        WaveCreated?.Invoke(size, speed);
    }
}
