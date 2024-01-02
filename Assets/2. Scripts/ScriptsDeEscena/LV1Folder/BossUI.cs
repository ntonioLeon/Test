using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject muros;

    public static BossUI instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        bossPanel.SetActive(false);
        muros.SetActive(false);
    }

    public void BossActivation()
    {
        bossPanel.SetActive(true);
        muros.SetActive(true);
    }

    public void bossDesactivator()
    {
        bossPanel.SetActive(false);
        muros.SetActive(false);
        StartCoroutine(BossDefeat());
    }

    IEnumerator BossDefeat()
    {
        var currSpeed = PlayerControler.instance.velocidad;
        PlayerControler.instance.movimientoBloqueado = true;
        PlayerControler.instance.Modificador(0);
        AudioMannager.instance.PlayAudio(AudioMannager.instance.deathBoss);
        yield return new WaitForSeconds(5f);
        PlayerControler.instance.movimientoBloqueado = false;
        PlayerControler.instance.Modificador(currSpeed);
        Destroy(gameObject);
    }
}
