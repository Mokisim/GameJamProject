using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingStick : MonoBehaviour
{
    public event Action<float, float> WaveCreated;

    [SerializeField] private Player _player;
    [SerializeField] private PlayerWave _wavePrefab;
    [SerializeField] private int _wavesCount;
    [SerializeField] private float _waveSpeed;
    [SerializeField] private float _waveSize;
    [SerializeField] private float _waveSizeDecrease;

    private Coroutine _coroutine;
    private float _cooldown = 1;
    private WaitForSeconds _wait;
    private float _waitTime = 0.5f;
    private float _nextActionTime;

    private void Awake()
    {
        _wait = new WaitForSeconds(_waitTime);
    }

    private void Update()
    {
        if (Time.time >= _nextActionTime)
        {
            _coroutine = StartCoroutine(Knocking());
        }
    }

    private IEnumerator Knocking()
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
        PlayerWave wave = Instantiate(_wavePrefab, transform.position, transform.rotation);
        WaveCreated?.Invoke(size, speed);
    }
}
