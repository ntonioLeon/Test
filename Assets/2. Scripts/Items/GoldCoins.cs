using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : MonoBehaviour
{
    public int dineroAGanar;
    private bool tomado;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !tomado) 
        {
            tomado = true;
            BankAccount.instance.Money(dineroAGanar);
            AudioMannager.instance.PlayAudio(AudioMannager.instance.coin);
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
