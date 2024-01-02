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
            StartCoroutine(esperarBoss());
        } 
    }

    IEnumerator esperarBoss()
    {
        /*PlayerControler.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        PlayerControler.instance.GetComponent<Animator>().SetBool("Correr", false);
        if (Input.GetAxisRaw("Horizontal") != 0) 
        {
            PlayerControler.instance.GetComponent<Animator>().SetBool("Correr", false);
        }
        PlayerControler.instance.GetComponent<Animator>().SetBool("Correr", false);
        yield return new WaitForSeconds(3f);
        PlayerControler.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        PlayerControler.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;*/
        PlayerControler.instance.velocidad = 0;
        yield return new WaitForSeconds(3f);
        PlayerControler.instance.velocidad = PlayerControler.instance.velocidadBase;
        Destroy(gameObject);
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
