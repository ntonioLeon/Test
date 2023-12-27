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
    public float knoclBackForceX;
    public float knoclBackForceY;
    public float dannoInfringido;


    Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
