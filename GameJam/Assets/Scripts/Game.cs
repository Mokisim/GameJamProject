using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private DeathScreen _deathScreen;
    [SerializeField] private int _scene;

    public void CastGameOver()
    {
        Time.timeScale = 0f;
        _deathScreen.Open();
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene(_scene);
    }
}
