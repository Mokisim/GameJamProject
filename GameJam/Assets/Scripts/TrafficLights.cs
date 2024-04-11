using System;
using System.Collections;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public event Action TrafficLightsOn;
    public event Action TrafficLightsOff;

    [SerializeField] private Clue _image;
    
    private WaitForSeconds _wait;
    private int _waitTime = 7;
    private Coroutine _coroutine;
    private float _nextActionTime;

    private void Awake()
    {
        _wait = new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true)
        {
            _image.Open();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true && Input.GetKeyDown(KeyCode.E) == true)
        {
            if (_nextActionTime <= Time.time)
            {
                TrafficLightsOff.Invoke();
                _coroutine = StartCoroutine(StartTimer());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _image.Close();
    }

    private IEnumerator StartTimer()
    {
        _nextActionTime = Time.time + _waitTime;
        
        int timer = 0;

        for(int i = 0; i < _waitTime; i++)
        {
            timer++;

            yield return _wait;
        }

        if(timer == _waitTime)
        {
            TrafficLightsOn.Invoke();
        }
    }
}
