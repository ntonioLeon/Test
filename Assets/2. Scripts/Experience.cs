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
        currentExp = PlayerPrefs.GetFloat("currentExp", 0f);
        expTNL = PlayerPrefs.GetFloat("expTNL", expTNL);
        lvl = PlayerPrefs.GetInt("lvl", 1);
        textLvl.text = lvl.ToString();  
        expImage.fillAmount = currentExp / expTNL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExpModifier(float exp) 
    {
        //currentExp = PlayerPrefs.GetFloat("currentExp", 0f);
        currentExp += exp;
        //expTNL = PlayerPrefs.GetFloat("expTNL", expTNL);

        if (currentExp >= expTNL) 
        {
            currentExp= currentExp-expTNL;//
            expTNL = expTNL * 2;
            float vida = (PlayerHealt.instance.health / PlayerHealt.instance.maxHealth );
            PlayerHealt.instance.maxHealth += incrementoVida;//
            PlayerHealt.instance.health = PlayerHealt.instance.maxHealth * vida;
            SubItems.instance.maxTotal += incrementoItems;
            AudioMannager.instance.PlayAudio(AudioMannager.instance.lvlUP);
            lvl++;
            textLvl.text = lvl.ToString();
        }
        expImage.fillAmount = currentExp / expTNL;
    }

    public void DataToSave()
    {
        if (DataMannager.instance != null)
        {
            Debug.Log("Llamada");
            DataMannager.instance.Experience(currentExp);
            Debug.Log("1");
            DataMannager.instance.Level(lvl);
            Debug.Log("2");
            DataMannager.instance.ExpTNL(expTNL);
            Debug.Log("EXP");
            DataMannager.instance.CurrentSubItem(SubItems.instance.total);
            DataMannager.instance.MaxSubItem(SubItems.instance.maxTotal);
            DataMannager.instance.CurrentCoins(BankAccount.instance.bank);
            Debug.Log("Items");
            DataMannager.instance.MaxHealth(PlayerHealt.instance.maxHealth);
            DataMannager.instance.CurrentHealth(PlayerHealt.instance.health);
            Debug.Log("VIDA");
            DataMannager.instance.CuurrentPosition(PlayerControler.instance.transform.position);

        }
        else
        {
            Debug.LogError("DataMannager.instance is null");
        }
       


    }
    public void DataToLoad()
    {
        currentExp = PlayerPrefs.GetFloat("currentExp", 0f);
        lvl = PlayerPrefs.GetInt("lvl", 1);
        expTNL = PlayerPrefs.GetFloat("expTNL", expTNL);

        SubItems.instance.total = PlayerPrefs.GetInt("total", 0);
        SubItems.instance.maxTotal = PlayerPrefs.GetInt("maxTotal", SubItems.instance.maxTotal);
        BankAccount.instance.bank = PlayerPrefs.GetInt("bank", 0);

        PlayerHealt.instance.maxHealth = PlayerPrefs.GetFloat("maxHealth", PlayerHealt.instance.maxHealth);
        PlayerHealt.instance.health = PlayerPrefs.GetFloat("health", PlayerHealt.instance.health);
        PlayerControler.instance.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
    }
}
