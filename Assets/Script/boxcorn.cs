using Unity.VisualScripting;
using UnityEngine;

public class boxcorn : MonoBehaviour
{
    public GameObject player;

    private bool isplayercol = false;
    private bool carryon = false;

    private Vector3 boxspawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxspawn = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(isplayercol && !carryon)
            {
                carryon = true;
            }
            else if(carryon)
            {
                putdownbox();
            }
        }

        if(carryon)
        {
            carrybox();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            isplayercol = true;
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
        
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            isplayercol = false;
        }
    }

    private void carrybox()
    {
        if (carryon)
        {
            this.transform.position = player.transform.position + new Vector3(0, 1, 0);
        }
    }

    private void putdownbox()
    {
        carryon = false;

        Vector3 playerposition = player.transform.position;

        player.transform.position = this.transform.position;

        this.transform.position = playerposition;
    }

    public void ResetBox()
    {
        carryon = false;
        isplayercol = false;
        this.transform.position = boxspawn;
    }
}
