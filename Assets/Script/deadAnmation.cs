using UnityEngine;

public class deadAnmation : MonoBehaviour
{

    private float moveSpeed = 5f;

    private Vector3 newposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newposition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y >  newposition.y - 35)
        {
            this.transform.Translate(new Vector3(0f, -2 * moveSpeed, 0f) * Time.unscaledDeltaTime);
        }
        else
        {
            Manager.is_reset = true;
        }

        if(this.transform.position.y < newposition.y - 20)
        {
            Manager.reset = true;
        }

        if (Manager.is_reset)
        {
            Destroy(this.gameObject);
        }
    }
}
