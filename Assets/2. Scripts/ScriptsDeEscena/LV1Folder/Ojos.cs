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
        //Vector2 malo = GetComponent<BossBehavior>().transform.position;

        Vector2 adjustedTargetPosition = target.transform.position - new Vector3(0f, 0.5f, 0);

        moveDirection = (adjustedTargetPosition - (Vector2)transform.position).normalized * moveSpeed;

        if (moveDirection.x < 0)
        {
            // Mira a la derecha
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Mira a la izquierda
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        AudioMannager.instance.PlayAudio(AudioMannager.instance.fireball);
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Suelos")) 
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
