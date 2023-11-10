using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panelPause;
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
    
}
