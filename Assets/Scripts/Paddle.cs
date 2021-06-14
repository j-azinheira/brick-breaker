using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePosInUnits, minX, maxX);

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
}
