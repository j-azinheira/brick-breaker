using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string gameOverSceneName = "3 - Game Over Screen Scene";

        SceneManager.LoadScene(gameOverSceneName);
    }
}
