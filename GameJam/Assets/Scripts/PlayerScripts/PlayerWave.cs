using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWave : MonoBehaviour
{
    private Player _player;
    private Coroutine _coroutine;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.position = _player.transform.position;
    }

    private void OnEnable()
    {
        _player.GetComponent<PlayerWalkingStick>().WaveCreated += StartIncreaseSize;
    }

    private void OnDisable()
    {
        _player.GetComponent<PlayerWalkingStick>().WaveCreated += StartIncreaseSize;
    }

    private void StartIncreaseSize(float size, float speed)
    {
        _coroutine = StartCoroutine(IncreaseSize(size, speed));
    }

    private IEnumerator IncreaseSize(float size, float speed)
    {
        float currentSize = 0;
        float targetSize = 1;

        while (currentSize < targetSize)
        {
            currentSize = Mathf.Sqrt((Mathf.Pow(transform.localScale.x, 2) + Mathf.Pow(transform.localScale.y, 2) + Mathf.Pow(transform.localScale.z, 2)));
            targetSize = Mathf.Sqrt((Mathf.Pow(size, 2) + Mathf.Pow(size, 2) + Mathf.Pow(1, 2)));

            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(size, size, 1), speed * Time.deltaTime);
            //transform.localScale = new Vector3(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime, 1);

            yield return new WaitForSeconds(0.001f);
        }

        gameObject.SetActive(false);
    }
}
