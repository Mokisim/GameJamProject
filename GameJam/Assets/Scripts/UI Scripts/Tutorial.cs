using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void OpenTutorial()
    {
        gameObject.SetActive(true);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
