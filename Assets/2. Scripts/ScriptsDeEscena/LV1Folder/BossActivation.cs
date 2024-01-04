using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossGM;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivation();
            AudioMannager.instance.background.Stop();
            AudioMannager.instance.PlayAudio(AudioMannager.instance.backgroundFight);
            StartCoroutine(Espera());
        } 
    }
    IEnumerator Espera()
    {
        AudioMannager.instance.PlayAudio(AudioMannager.instance.bossApear);
        var currSpeed = PlayerControler.instance.velocidad;
        PlayerControler.instance.movimientoBloqueado = true;
        PlayerControler.instance.Modificador(0);
        bossGM.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerControler.instance.movimientoBloqueado = false;
        PlayerControler.instance.Modificador(currSpeed);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        bossGM.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
