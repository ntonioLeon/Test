using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float tiempoParaDisparar;
    public float shootCooldown;

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
        GameObject gameObject = Instantiate(proyectil, transform.position, Quaternion.identity); //Para cambiar el nacimiento cambiar el transform.

        if (transform.localScale.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0), ForceMode2D.Force);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0), ForceMode2D.Force);
        }

        shootCooldown = tiempoParaDisparar;
    }
}
