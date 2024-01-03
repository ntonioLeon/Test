using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public float timeToRespawn;
    public GameObject enemyToRespawn;
    public bool isRespawning;

    // Start is called before the first frame update
    void Start()
    {
        enemyToRespawn = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator RespawnEnemy()
    {
        enemyToRespawn.SetActive(false);
        
        yield return new WaitForSeconds(timeToRespawn);
        enemyToRespawn.SetActive(true);
        
        enemyToRespawn.GetComponent<Enemy>().healtPoints =
           enemyToRespawn.GetComponent<EnemyHealth>().originalHealth;
        
        enemyToRespawn.GetComponent<SpriteRenderer>().material =
           enemyToRespawn.GetComponent<Blick>().original;
        
        enemyToRespawn.GetComponent<EnemyHealth>().recibeDanno = false;

        //Aqui deberia ir la llamada al IENumerator que lleve la animacion de respawn
     }    
}
