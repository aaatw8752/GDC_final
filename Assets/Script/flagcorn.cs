using UnityEngine;

public class flagcorn : MonoBehaviour
{
    public bool isEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            isEnd = true;
            Debug.Log("Player has reached the end point!");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            isEnd = false;
            Debug.Log("Player has left the end point!");
        }
    }
}
