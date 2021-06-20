using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip powerUpSound;
    [SerializeField] GameObject powerUpSparklesVFX;

    // Cached component references
    [SerializeField] Ball ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyPowerUp();

        ball.IncreaseBallSize();
    }

    private void DestroyPowerUp()
    {
        TriggerSparklesVFX();

        AudioSource.PlayClipAtPoint(powerUpSound, Camera.main.transform.position);

        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(powerUpSparklesVFX, transform.position, transform.rotation);

        Destroy(sparkles, 1f);
    }
}
