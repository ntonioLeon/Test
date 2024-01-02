using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;
    PlayerControler target;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        target = PlayerControler.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
