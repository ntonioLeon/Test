using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivation();
            StartCoroutine(Espera());
        } 
    }
    IEnumerator Espera()
    {
        var currSpeed = PlayerControler.instance.velocidad;
        Debug.Log("Deberia estar esperando");
        PlayerControler.instance.movimientoBloqueado = true;
        PlayerControler.instance.Modificador(0);
        yield return new WaitForSeconds(3f);
        PlayerControler.instance.movimientoBloqueado = false;
        PlayerControler.instance.Modificador(currSpeed);
        Destroy(gameObject);
        Debug.Log("He terminado de esperar");
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
