using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Weapon"))
        {
            enemy.healtPoints -= 2f;

            if (enemy.healtPoints <= 0)
            {
                enemy.anim.SetBool("Muerto", true);
                ///Destroy(gameObject);
                enemy.anim.SetBool("Muerto", false);
            }
        }
    }
}
