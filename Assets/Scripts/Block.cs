using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakSound;

    // Cached reference
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();

        gameStatus = FindObjectOfType<GameStatus>();

        level.CountBreakableBlocks();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);

        Destroy(gameObject, 0f);

        level.BlockDestroyed();

        gameStatus.AddScore();
    }
}
