using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyProyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float tiempoParaDisparar;
    public float shootCooldown;
    public float shootSpeed;
    public float fixHigh;

    public bool disparoConstante;
    public bool watcher;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = tiempoParaDisparar;
    }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= Time.deltaTime;

        if (disparoConstante)
        {
            if (shootCooldown < 0)
            {
                Shoot();
            }
        }

        if (watcher)
        {

        }
    }

    public void Shoot()
    {
        GameObject gameObject = Instantiate(proyectil, transform.position, Quaternion.identity);

        Vector3 nuevaPosicion = gameObject.transform.position;
        nuevaPosicion.y += fixHigh;
        gameObject.transform.position = nuevaPosicion;

        if (transform.localScale.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(shootSpeed, 0), ForceMode2D.Force);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-shootSpeed, 0), ForceMode2D.Force);
        }

        shootCooldown = tiempoParaDisparar;
    }
}