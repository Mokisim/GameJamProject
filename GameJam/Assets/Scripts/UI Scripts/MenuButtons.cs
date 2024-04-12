using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Authors _authors;
    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private CurrentCamera _currentCamera;

    public void Play()
    {
        _tutorial.OpenTutorial();
    }

    public void OpenAuthors()
    {
        _currentCamera.GetComponent<AudioSource>().Stop();
        _authors.OpenAuthors();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
