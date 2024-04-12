using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Dog _dog;
    [SerializeField] private Transform _transform;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) == true && Input.GetKeyDown(KeyCode.E))
        {
            _image.gameObject.SetActive(true);
            _dog.transform.position = _transform.position;
        }
    }
}
