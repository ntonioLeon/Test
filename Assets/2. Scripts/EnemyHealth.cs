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
    public Rigidbody2D rb;

    public float originalHealth;
    

    // Start is called before the first frame update
    void Start()
    {        
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();

        render = GetComponent<SpriteRenderer>();
        material = GetComponent<Blick>();

        originalHealth = enemy.healtPoints;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Weapon") && !recibeDanno)
        {
            enemy.healtPoints -= 1f;

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
                Experience.instance.ExpModifier(GetComponent<Enemy>().expToGive);

                if (enemy.shouldRespawn)
                {
                    transform.GetComponentInParent<EnemyRespawn>().StartCoroutine(GetComponentInParent<EnemyRespawn>().RespawnEnemy());
                } 
                else 
                {
                    Destroy(gameObject);
                }                
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
