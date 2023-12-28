using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAccount : MonoBehaviour
{
    public int bank;
    public Text bankText;

    public static BankAccount instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Money(int cash)
    {
        bank += cash;
        bankText.text = bank.ToString() +" Ptas";
    }

    // Start is called before the first frame update
    void Start()
    {
        bankText.text = bank.ToString() + " Ptas";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
