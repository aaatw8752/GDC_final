using Unity.VisualScripting;
using UnityEngine;

public class GunFirecorn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Creating GunFirecorn object.");
        Destroy(gameObject, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
