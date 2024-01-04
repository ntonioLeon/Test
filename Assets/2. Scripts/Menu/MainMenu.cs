using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "0.MainMenu") 
        {
            AudioMannager.instance.background.Stop();
            //Parar lo demas
            AudioMannager.instance.PlayAudio(AudioMannager.instance.mainMenu);
        }
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() 
    {
        AudioMannager.instance.mainMenu.Stop();
        SceneManager.LoadScene(1);
    }
    public void ToMainMenu()
    {
        AudioMannager.instance.background.Stop();
        //Parar lo demas
        AudioMannager.instance.PlayAudio(AudioMannager.instance.mainMenu);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    public void ShowSettings()
    {
        anim.SetBool("SettingsOn", true);
    }
    public void HideSettings()
    {
        anim.SetBool("SettingsOn", false);
    }
}
