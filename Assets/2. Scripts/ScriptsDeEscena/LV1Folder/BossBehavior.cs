using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class BossBehavior : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject ojos;

    public float timeToShoot, timeToTeleport;
    float cooldown, teleportCooldown;
    public float bossHealth, currentHealth;
    public Image barraSalud;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = transforms[1].position;
        cooldown = timeToShoot;
        teleportCooldown = timeToTeleport;
    }

    // Update is called once per frame
    void Update()
    {
        Countdouwn();

        bossScale();

        damageBoss();
    }

    public void Countdouwn()
    {
        cooldown -= Time.deltaTime;
        teleportCooldown -= Time.deltaTime;

        if (cooldown < 0)
        {
            shootPlayer();
            cooldown = timeToShoot;

        }

        if (teleportCooldown < 0)
        {
            teleportCooldown = timeToTeleport;
            teleport();
        }
    }

    public void shootPlayer()
    {
        GameObject spell = Instantiate(ojos, transform.position, Quaternion.identity);
    }

    public void teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }

    public void damageBoss()
    {
        currentHealth = GetComponent<Enemy>().healtPoints;
        barraSalud.fillAmount = currentHealth / bossHealth;
    }

    public void bossScale()
    {
        if (transform.position.x > PlayerControler.instance.transform.position.x) 
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnDestroy()
    {
        BossUI.instance.bossDesactivator();
    }
}
