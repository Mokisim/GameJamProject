using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
