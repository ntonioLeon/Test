using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    /// <summary>
    /// Datos del enemigo
    /// </summary>
    public string enemyName;
    public float healtPoints;
    public float speed;

    public Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FlipedCharacter()
    {
        //If que determina si va a la izquierda o derecha
        if (rb.velocity.x > 0) //derecha
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (rb.velocity.x < 0) //izquierda
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
    }
}
