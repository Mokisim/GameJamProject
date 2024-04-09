using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] Camera _camera;
    [SerializeField] private AudioSource _audioSource;
    
    private Rigidbody2D _rb;
    private Vector2 _mousePosition;
    private Vector2 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if(_camera == null)
        {
            _camera = FindObjectOfType<Camera>();
        }
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if(_movement.x != 0 || _movement.y != 0)
        {
            if(_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }
        }
        else
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Stop();
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);

        Vector2 lookDirection = _mousePosition - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }
}
