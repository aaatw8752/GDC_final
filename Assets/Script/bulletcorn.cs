using UnityEngine;

public class bulletcorn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 6.5f;
    
    void Start()
    {
        Manager.is_shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition += -this.transform.up * speed * Time.deltaTime;
        if(Manager.is_shoot)
        {
            destroyBullet();
            Manager.is_shoot = false;
        }

        if(Manager.dead)
        {
            this.GetComponent<Collider2D>().enabled = false;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Debug.Log("Player hit by bullet!");
            Manager.dead = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void destroyBullet()
    {
        Destroy(this.gameObject);
    }
}
