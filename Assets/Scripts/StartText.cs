using UnityEngine;

public class StartText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveTextOnStart();
    }

    private void RemoveTextOnStart()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(true);
        }
    }
}
