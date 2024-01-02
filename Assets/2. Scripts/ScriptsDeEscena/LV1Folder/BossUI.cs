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
}
