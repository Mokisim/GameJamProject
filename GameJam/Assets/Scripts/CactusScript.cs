using UnityEngine;
using UnityEngine.SceneManagement;

public class CactusScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
