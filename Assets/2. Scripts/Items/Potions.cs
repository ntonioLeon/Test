using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour

{
    public float vidaRecibida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            collision.GetComponent<PlayerHealt>().health+= vidaRecibida;
            Destroy(gameObject);
        }
    }











    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
