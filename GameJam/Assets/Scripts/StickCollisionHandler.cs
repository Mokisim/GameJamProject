using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EButton _eButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true)
        {
            _eButton.Open();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true && Input.GetKeyDown(KeyCode.E) == true)
        {
            Destroy(gameObject);
            Instantiate(_player, player.transform.position, player.transform.rotation);
            Destroy(player.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _eButton.Close();
    }
}
