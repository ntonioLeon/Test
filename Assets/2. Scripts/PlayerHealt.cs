using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// /ESTO ESTA MAL PRODUCE FALLOS
/// </summary>
public class PlayerHealt : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthImage;
    bool isInmune;
    public float inmunerableTime;
    Blick material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    public float knockBackX;
    public float knockBackY;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blick>();
        health = maxHealth;
        material.original = sprite.material;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / 100;
        if (health > maxHealth) 
        { 
            health= maxHealth;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune) 
        {
            health-=collision.GetComponent<Enemy>().dannoInfringido;
            StartCoroutine(Inmunity());

            if (collision.transform.position.x > transform.position.x) 
            {
                rb.AddForce(new Vector2(-knockBackX, knockBackY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockBackX, knockBackY), ForceMode2D.Force);
            }
            
            if (health <= 0) 
            {
                StartCoroutine(Morirse());
            }
        }
    }
    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.parpadeo;
        yield return new WaitForSeconds(inmunerableTime);
        sprite.material = material.original;
        isInmune = false;
    }



    IEnumerator Morirse()
    {
        anim.SetBool("Muerte", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
