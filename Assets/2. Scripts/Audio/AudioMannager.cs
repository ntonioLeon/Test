using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMannager : MonoBehaviour
{
    public AudioMixer musicMix, effectsMix;
    public AudioSource background, bossApear, risa, mainMenu, backgroundFight, coin, bump, deathBoss, deathPlayer, fireball, lvlUP;
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
        //PlayAudio(background);

        musicSli.minValue = -80;
        musicSli.maxValue = -10;

        effectsSli.minValue = -80;
        effectsSli.maxValue = 10;

        //musicSli.value = -40;
        //effectsSli.value = -20;

        musicSli.value = PlayerPrefs.GetFloat("musica", -50f);
        effectsSli.value = PlayerPrefs.GetFloat("effectsVolume", -20f);
    }

    // Update is called once per frame
    void Update()
    {
        DataMannager.instance.MusicData(musicSli.value);
        musicMix.SetFloat("MixVol", PlayerPrefs.GetFloat("musica"));

        //MasterVol();
        //EffectsVol();
    }
    public void MasterVol()
    {
        //TPM
        //DataMannager.instance.MusicData(musicSli.value);
        //musicMix.SetFloat("MixVol", PlayerPrefs.GetFloat("musica"));
        //MixVol;
    }
    public void EffectsVol()
    {
        DataMannager.instance.EffectsMusicData(effectsSli.value);
        effectsMix.SetFloat("effectsVolume", PlayerPrefs.GetFloat("effectsVolume"));
        
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
