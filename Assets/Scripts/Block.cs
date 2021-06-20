using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int blockHitPoints = 3;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;
    GameSession gameStatus;

    // State variables
    [SerializeField] int timesBlockHit = 0; // Serialized for debugging

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        gameStatus = FindObjectOfType<GameSession>();

        if (gameObject.tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag != "Unbreakable")
        {
            timesBlockHit++;

            int blockHitPoints = hitSprites.Length + 1;

            if (timesBlockHit >= blockHitPoints )
            {
                DestroyBlock();
            } else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesBlockHit - 1;

        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();

        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);

        Destroy(gameObject, 0f);

        level.BlockDestroyed();

        gameStatus.AddScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

        Destroy(sparkles, 1f);
    }
}
