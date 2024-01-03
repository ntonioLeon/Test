using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuaseMenu : MonoBehaviour
{
    public GameObject pause;
    public bool isPaused;

    // Awake is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseActivation();
    }
    public void PauseActivation()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) 
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            isPaused = false;
        }
    }
}
