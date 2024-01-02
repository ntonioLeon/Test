using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class Experience : MonoBehaviour
{
    public Image expImage;
    public float currentExp;
    public float expTNL;
    public float incrementoVida;
    public int incrementoItems;
    public Text textLvl;

    int lvl;

    public static Experience instance;

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
        lvl = 1;
        textLvl.text = lvl.ToString();  
        expImage.fillAmount = currentExp / expTNL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExpModifier(float exp) 
    {
        currentExp += exp;
        if (currentExp >= expTNL) 
        {
            currentExp= currentExp-expTNL;
            expTNL = expTNL * 2;
            float vida = (PlayerHealt.instance.health / PlayerHealt.instance.maxHealth );
            PlayerHealt.instance.maxHealth += incrementoVida;
            PlayerHealt.instance.health = PlayerHealt.instance.maxHealth * vida;
            SubItems.instance.maxTotal += incrementoItems;
            AudioMannager.instance.PlayAudio(AudioMannager.instance.lvlUP);
            lvl++;
            textLvl.text = lvl.ToString();
        }
        expImage.fillAmount = currentExp / expTNL;
    }
}
