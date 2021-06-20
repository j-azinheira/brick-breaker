using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Cached component references
    GameSession gameSession;
    Ball ball;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>();

        gameSession = FindObjectOfType<GameSession>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePosition;

        ResetPaddleOnMouseClick();
    }

    private void ResetPaddleOnMouseClick()
    {
        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<PolygonCollider2D>().transform.position = new Vector2(7f, 1f);
        }
    }

    private float GetXPos()
    {
        if(this.gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
