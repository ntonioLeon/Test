using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMannager : MonoBehaviour
{
    public AudioMixer musicMix, effectsMix;
    public AudioSource background, coin, bump, deathBoss, deathPlayer, fireball, lvlUP;
    [Range(-80, -10)]
    public float musicVol, effectsVol;
    public Slider musicSli, effectsSli; 

    public static AudioMannager instance;

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
        PlayAudio(background);
        
        musicSli.minValue = -80;
        musicSli.maxValue = -10;

        effectsSli.minValue = -80;
        effectsSli.maxValue = 10;

        musicSli.value = -40;
        effectsSli.value = -20;
    }

    // Update is called once per frame
    void Update()
    {
        MasterVol();
        EffectsVol();
    }
    public void MasterVol()
    {
        musicMix.SetFloat("masterVolume", musicSli.value);
    }
    public void EffectsVol()
    {
        effectsMix.SetFloat("effectsVolume", effectsSli.value);
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
