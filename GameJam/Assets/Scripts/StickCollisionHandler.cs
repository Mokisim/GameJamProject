using System;
using UnityEngine;

public class StickCollisionHandler : MonoBehaviour
{
    public event Action StickGetted;

    [SerializeField] private Player _player;
    [SerializeField] private Clue _image;

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
            Destroy(gameObject);
            Instantiate(_player, player.transform.position, player.transform.rotation);
            StickGetted.Invoke();
            Destroy(player.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _image.Close();
    }
}
