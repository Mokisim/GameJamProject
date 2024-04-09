using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DogsWave : MonoBehaviour
{
    private Dog _dog;
    private Coroutine _coroutine;
    private float _changeColorSpeed = 0.1f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _dog = FindObjectOfType<Dog>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _dog.GetComponent<WoofSkill>().WaveCreated += StartIncreaseSize;
    }

    private void OnDisable()
    {
        _dog.GetComponent<WoofSkill>().WaveCreated += StartIncreaseSize;
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

            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _spriteRenderer.color.a - _changeColorSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0.001f);
        }

        gameObject.SetActive(false);
    }
}
