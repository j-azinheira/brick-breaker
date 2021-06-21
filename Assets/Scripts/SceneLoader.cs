using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    GameSession gameSession;

    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        
        if(gameSession != null)
        {
            gameSession.ResetGameStatus();
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        Navigate();
    }

    private void Navigate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            LoadNextScene();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            QuitGame();
        }

        if (Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("Credits");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            LoadStartScene();
        }
    }
}
