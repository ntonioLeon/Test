using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubWeapon : MonoBehaviour
{
    public int costeArma;
    public GameObject proyectil;
    public float velocidadProyectil;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UsoSubWeapon();
    }

    public void UsoSubWeapon() 
    {
        if (Input.GetButtonDown("Fire2") && costeArma <= SubItems.instance.total) 
        {
            SubItems.instance.Abastecimiento(-costeArma);
            GameObject disparo = Instantiate(proyectil, transform.position, Quaternion.Euler(0,0,0));

            if (transform.localScale.x < 0)
            {
                disparo.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocidadProyectil, 0f), ForceMode2D.Force);
                disparo.transform.localScale = new Vector2(-2, -2);
            }
            else 
            {
                disparo.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidadProyectil, 0f), ForceMode2D.Force);
                disparo.transform.localScale = new Vector2(2, 2);
            }
        }
    }
}
