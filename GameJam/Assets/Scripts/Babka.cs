using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babka : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 4f;

    private Transform[] _points;
    private int _currentPoint;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _points = new Transform[_path.childCount];

        for(int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Patrol();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    private void Patrol()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint = ++_currentPoint % _points.Length;
        }
    }
}
