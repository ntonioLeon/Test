using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubItem : MonoBehaviour
{

    public int subItemsRecibes;
    private bool tomado; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !tomado)
        {
            tomado = true;
            SubItems.instance.Abastecimiento(subItemsRecibes);
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
