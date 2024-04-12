using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authors : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private CurrentCamera _currentCamera;

    public void OpenAuthors()
    {
        gameObject.SetActive(true);
        _audioSource.Play();
    }

    public void CloseAuthors()
    {
        _currentCamera.GetComponent<AudioSource>().Play();
        _audioSource.Stop();
        gameObject.SetActive(false);
    }
}
