using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;

    public GameObject deathEffect;
    public bool recibeDanno;

    SpriteRenderer render;
    Blick material;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();

        render = GetComponent<SpriteRenderer>();
        material = GetComponent<Blick>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Weapon") && !recibeDanno)
        {
            enemy.healtPoints -= 2f;

            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knoclBackForceX, enemy.knoclBackForceY), ForceMode2D.Force);
            } 
            else
            {
                rb.AddForce(new Vector2(-enemy.knoclBackForceX, enemy.knoclBackForceY), ForceMode2D.Force);
            }
            

            StartCoroutine(Damager());
            if (enemy.healtPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                
                Destroy(gameObject);;
            }
        }
    }

    /// <summary>
    /// Apriori esto detecta el daño y setea la invulnerabilidad
    /// </summary>
    /// <returns></returns>
    IEnumerator Damager()
    {
        recibeDanno = true;
        render.material = material.parpadeo;
        yield return new WaitForSeconds(0.5f);
        render.material = material.original;
        recibeDanno = false;
    }
}
