using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubItems : MonoBehaviour
{
    public Text SubItemsText;
    public int maxTotal;
    public int total;
    

    public static SubItems instance;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
        }
    }
    public void Abastecimiento(int cantidadRecibida) 
    {
        total += cantidadRecibida;
        if (total > maxTotal) 
        {
            total = maxTotal;
        }
        SubItemsText.text = total.ToString();

    }

    // Start is called before the first frame update
    void Start()
    {

        SubItemsText.text = total.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
