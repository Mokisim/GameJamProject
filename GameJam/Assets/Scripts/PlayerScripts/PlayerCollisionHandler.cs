using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Game _game;

    private void Awake()
    {
        if(_game == null)
        {
            _game = FindObjectOfType<Game>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            _game.CastGameOver();
        }
        else if(other.TryGetComponent(out Dog dog) == true)
        {
            _game.LoadNewLevel();
        }
    }
}
