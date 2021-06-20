using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    GameSession gameStatus;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

        //gameStatus.ResetGameStatus();

        FindObjectOfType<GameSession>().ResetGameStatus();
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
        if(Input.GetKey("escape"))
        {
            LoadStartScene();
        }
    }
}
