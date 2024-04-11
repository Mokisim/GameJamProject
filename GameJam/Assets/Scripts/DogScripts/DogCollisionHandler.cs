using System;
using UnityEngine;

public class DogCollisionHandler : MonoBehaviour
{
    [SerializeField] private Game _game;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) == true)
        {
            _game.SetActive();
        }
    }
}
