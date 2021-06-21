using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    TextMeshProUGUI[] tutorialText;

    // State variables
    [SerializeField] int timesBlockHit = 0; // Serialized for debugging

    private void Start()
    {
        CountBreakableBlocks();

        tutorialText = FindObjectsOfType<TextMeshProUGUI>();
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
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Tutorial")
        {
            TutorialLogic();
        }

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

    private void TutorialLogic()
    {
        foreach(var text in tutorialText)
        {
            if(gameObject.name == "1-Hit Block")
            {
                text.SetText("trap");
            }
        }
    }
}
