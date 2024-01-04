using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMannager : MonoBehaviour
{
    public static DataMannager instance;

void Awake()
{
    if (instance == null)
    {
        instance = this;
    }
}


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicData(float value)
    {
        PlayerPrefs.SetFloat("musica", value);
    }

    public void EffectsMusicData(float value)
    {
        PlayerPrefs.SetFloat("effectsVolume", value);
    }


    public void Experience(float value)
    {
        PlayerPrefs.SetFloat("currentExp", value);
    }
    public void Level(int value)
    {
        PlayerPrefs.SetInt("lvl", value);
    }
    public void ExpTNL(float value)
    {
        PlayerPrefs.SetFloat("expTNL", value);
    }
    public void CurrentSubItem(int value)
    {
        PlayerPrefs.SetInt("total", value);
    }
    public void MaxSubItem(int value)
    {
        PlayerPrefs.SetInt("maxTotal", value);
    }
    public void CurrentCoins(int value)
    {
        PlayerPrefs.SetInt("bank", value);
    }
    public void MaxHealth(float value)
    {
        PlayerPrefs.SetFloat("maxHealth", value);
    }
    public void CurrentHealth(float value)
    {
        PlayerPrefs.SetFloat("health", value);
    }
    public void CuurrentPosition(Vector2 pos) 
    {
        PlayerPrefs.SetFloat("x", pos.x);
        PlayerPrefs.SetFloat("y", pos.y);
    }
    



}
