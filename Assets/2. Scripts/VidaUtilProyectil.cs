using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaUtilProyectil : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Suelos")) 
        {
            //Efectos adicionales aqui. 
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
