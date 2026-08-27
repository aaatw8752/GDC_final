using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class move_contor : MonoBehaviour
{
    private float moveSpeed = 0;
    private float maxSpeed = 2f;

    private float currrentY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) && !Input.GetKeyUp(KeyCode.D))
        {
            if(moveSpeed < maxSpeed)
            {
                moveSpeed += 0.2f;
            }

            if(moveSpeed >= maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
        }
        else if(!Input.anyKey)
        {
            if (moveSpeed > 0)
            {
                moveSpeed -= 0.4f;
            }
            if (moveSpeed <= 0)
            {
                moveSpeed = 0;
            }
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKeyUp(KeyCode.A))
        {
            if (moveSpeed > -maxSpeed)
            {
                moveSpeed -= 0.2f;
            }

            if (moveSpeed <= -maxSpeed)
            {
                moveSpeed = -maxSpeed;
            }
        }
        else if (!Input.anyKey)
        {
            if (moveSpeed < 0)
            {
                moveSpeed += 0.4f;
            }
            if (moveSpeed >= 0)
            {
                moveSpeed = 0;
            }
        }
 
    }
}
