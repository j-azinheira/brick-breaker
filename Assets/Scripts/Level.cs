using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Parameters
    [SerializeField] int breakableBlocks;

    // Cached reference
    SceneLoader sceneLoader;
    Scene currentScene;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        Scene currentScene = SceneManager.GetActiveScene();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;

        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
