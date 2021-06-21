using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    // Cached references
    GameSession gameSession;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        scoreText = GetComponent<TextMeshProUGUI>();

        scoreText.text = gameSession.gameScore.ToString();
    }
}
