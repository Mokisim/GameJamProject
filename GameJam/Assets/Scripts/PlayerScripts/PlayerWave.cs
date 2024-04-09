using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerWave : MonoBehaviour
{
    private float _changeColorSpeed = 1f;
    private Player _player;
    private Coroutine _coroutine;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = _player.GetComponentInChildren<PlayerKnockPoint>().transform.position;
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
        _coroutine = StartCoroutine(ChangeParametrs(size, speed));
    }

    private IEnumerator ChangeParametrs(float size, float speed)
    {
        float currentNumber = 0;
        float targetNumber = 1;

        while (currentNumber < targetNumber)
        {
            currentNumber = Mathf.Sqrt((Mathf.Pow(transform.localScale.x, 2) + Mathf.Pow(transform.localScale.y, 2) + Mathf.Pow(transform.localScale.z, 2)));
            targetNumber = Mathf.Sqrt((Mathf.Pow(size, 2) + Mathf.Pow(size, 2) + Mathf.Pow(1, 2)));

            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(size, size, 1), speed * Time.deltaTime);

            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _spriteRenderer.color.a - _changeColorSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0.001f);
        }

        gameObject.SetActive(false);
    }
}
