using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoofSkill : MonoBehaviour
{
    public event Action<float, float> WaveCreated;

    [SerializeField] private Dog _dog;
    [SerializeField] private Wave _wavePrefab;
    [SerializeField] private int _wavesCount;
    [SerializeField] private float _waveSpeed;
    [SerializeField] private int _woofCount;
    [SerializeField] private float _waveSize;
    [SerializeField] private float _waveSizeDecrease;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Woof());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(_woofCount > 0)
            {
                _coroutine = StartCoroutine(Woof());
                _woofCount--;
            }
            else
            {
                if(_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                Debug.Log("Собачка убежала =(");
            }
        }
    }

    private IEnumerator Woof()
    {
        for (int i = 0; i < _wavesCount; i++)
        {
            float newWaveSize = _waveSize - _waveSizeDecrease * i;

            if(i == 0)
            {
                CreateSoundWaves(_waveSize, _waveSpeed);
            }
            else
            {
                CreateSoundWaves(newWaveSize, _waveSpeed);
            }

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("гав");
    }

    private void CreateSoundWaves(float size, float speed)
    {
        Wave wave = Instantiate(_wavePrefab, transform.position, transform.rotation);
        WaveCreated?.Invoke(size, speed);
    }
}
