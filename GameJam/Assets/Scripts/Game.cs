using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private int _nextScene;

    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }

    private void OpenNextLevel()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
