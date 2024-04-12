using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroStand : MonoBehaviour
{
    [SerializeField] private Clue _image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true)
        {
            _image.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _image.Close();
    }
}
