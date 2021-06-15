using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    [SerializeField] string nextScene;

    private void Update()
    {
        if(breakableBlocks == 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
}
