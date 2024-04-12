using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    private void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
