using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //parametros
    float speed;
    Rigidbody2D rb;
    Animator anim;
    public float radioDeteccion;
    public bool estaEsperando;
    public Transform precipicio, paredes, suelo;
    bool sueloDetectado, precipicioDetectado, paredDetectada;
    public LayerMask queEsSuelo;

    //Static
    public bool esEstatico;

    //Correr
    public bool esCaminante;
    bool andaIzquierda;

    //Patrullar
    public bool patrulla;
    public GameObject puntoA, puntoB;
    public Transform objetivo;
    bool debeEsperar;
    public float tiempoQueEspera;


    // Start is called before the first frame update
    void Start()
    {
        if (tiempoQueEspera > 0)
        {
            debeEsperar = true;
        }

        objetivo = puntoA.transform;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        precipicioDetectado = !Physics2D.OverlapCircle(precipicio.position, radioDeteccion, queEsSuelo);
        paredDetectada = Physics2D.OverlapCircle(paredes.position, radioDeteccion, queEsSuelo);
        sueloDetectado = Physics2D.OverlapCircle(suelo.position, radioDeteccion, queEsSuelo);

        if ( (precipicioDetectado || paredDetectada) && sueloDetectado)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        if (esEstatico)
        {
            anim.SetBool("Moverse", false); //Puesto que empezamos en idle y pasamos a movimientiento esto es al rev�s.
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
        if (esCaminante) 
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Moverse", true);

            if (andaIzquierda)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            } else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }

        if (patrulla)
        {
            Vector2 punto = objetivo.position - transform.position;

            if (objetivo == puntoA.transform)
            {
                if (!estaEsperando)
                {
                    anim.SetBool("Moverse", true);
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }                
            }
            else
            {
                if (!estaEsperando)
                {
                    anim.SetBool("Moverse", true);
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                
            }

            if ((transform.position.x - puntoA.transform.position.x) >= -radioDeteccion && objetivo == puntoA.transform) 
            {
                if (debeEsperar)
                {
                    StartCoroutine(Esperar());
                }

                Flip();
                objetivo = puntoB.transform;
            }

            if ((transform.position.x - puntoB.transform.position.x) <= radioDeteccion && objetivo == puntoB.transform)
            {
                if (debeEsperar)
                {
                    StartCoroutine(Esperar());
                }

                Flip();
                objetivo = puntoA.transform;
            }
        }
    }

    private void Flip()
    {
        if (andaIzquierda)
        {
            andaIzquierda = false;
            transform.localScale = new Vector3(3, 3, 3);
        }
        else
        {
            andaIzquierda = true;
            transform.localScale = new Vector3(-3, 3, 3); ;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(puntoA.transform.position, radioDeteccion);
        Gizmos.DrawWireSphere(puntoB.transform.position, radioDeteccion);
        Gizmos.DrawLine(puntoA.transform.position, puntoB.transform.position);
    }

    IEnumerator Esperar()
    {
        anim.SetBool("Moverse", false);
        estaEsperando = true;
        for (int i = 0; i < tiempoQueEspera; i++)
        {
            yield return new WaitForSeconds(1);

            Flip();            
        }
        if (tiempoQueEspera%2 == 1) {
            Flip();
        }
        estaEsperando = false;
        anim.SetBool("Moverse", true);
    }
}
