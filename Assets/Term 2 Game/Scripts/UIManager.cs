using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool IsPaused;

    public GameObject StartScreen;
    public GameObject StartCamera;
    public GameObject PauseScreen;
    public GameObject DeathScreen;
    public GameObject VictoryScreen;
    public GameObject SettingsScreen;
    public GameObject PlayerGui;
    public GameObject Player;
    public GameObject PlayerCamera;
    public AudioSource MegaClick;
    public AudioSource MinorClick;
    public AudioSource Music;
    public AudioSource VictoryMusic;
    public AudioSource DeathMusic;
    

    public bool PauseOn = false;

    private void Start()
    {
        if (StartScreen != null)
        {
            StartScreen.SetActive(true);
        }
        if (StartCamera != null)
        {
            StartCamera.SetActive(true);
        }
        if (PauseScreen != null)
        {
            PauseScreen.SetActive(false);
        }
        if (DeathScreen != null)
        {
            DeathScreen.SetActive(false);
        }
        if (VictoryScreen != null)
        {
            VictoryScreen.SetActive(false);
        }
        if (PlayerGui != null)
        {
            PlayerGui.SetActive(false);
        }
        if (PlayerCamera != null)
        {
            PlayerCamera.SetActive(false);
        }
        if (Player != null)
        {
            Player.SetActive(false);
        }

        if (StartScreen == null)
        {
            if (PlayerCamera != null)
            {
                PlayerCamera.SetActive(true);
            }
            if (Player != null)
            {
                Player.SetActive(true);
            }
            if (PlayerGui != null)
            {
                PlayerGui.SetActive(true);
            }
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseOn = !PauseOn;
        }
        if (PauseOn == true)
        {
            PauseActive();
        }
        if (VictoryScreen != null)
        {
            if (VictoryScreen.activeSelf == false)
            {
                if (SettingsScreen.activeSelf == false)
                {
                    if (PauseOn == false)
                    {
                        PauseInActive();
                    }
                }
                
            }
        }
        if (StartScreen != null)
        {
            if (StartScreen.activeSelf == true)
            {
                if (PauseScreen != null)
                {
                    PauseScreen.SetActive(false);
                }
                PauseOn = false;
            }
        }

        if (Player != null)
        {
            if (Player.activeSelf == false)
            {
                PlayerGui.SetActive(false);
                DeathScreen.SetActive(true);
                Music.enabled = false;
                DeathMusic.enabled = true;
            }
        }
        if (VictoryScreen != null)
        {
            if (VictoryScreen.activeSelf == true)
            {
                Time.timeScale = 0.0F;
                PlayerGui.SetActive(false);
                Player.GetComponent<Movement>().enabled = false;
                Music.enabled = false;
                VictoryMusic.enabled = true;

            }
        }

    }

    public void OnStartPressed()
    {
        //Enter code here to start the game
        SceneManager.LoadScene(1);
        //Debug.Log("START GAME");

        //Player.SetActive(true);
        //PlayerCamera.SetActive(true);
        //PlayerGui.SetActive(true);
        //StartCamera.SetActive(false);
        //StartScreen.SetActive(false);

        
    }
    public void OnPressed()
    {
        Debug.Log("pressed");
        MegaClick.Play();
    }
    public void OnHighLight()
    {
        Debug.Log("pressed");
        MinorClick.Play();
    }
    public void PauseUI()
    {
        PauseOn = true;
        PauseActive();
        
    }
    public void PauseActive()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0.0F;
        PlayerGui.SetActive(false);
        Player.GetComponent<Movement>().enabled = false;
        Music.volume = 0.15f;


    }
    public void PauseInActive()
    {
        PauseOn = false;
        if (PauseScreen != null)
        {
            PauseScreen.SetActive(false);
        }
        Time.timeScale = 1F;
        if (Player != null)
        {
            Player.GetComponent<Movement>().enabled = true;
        }
        if (PlayerGui != null)
        {
            PlayerGui.SetActive(true);
        }
        Music.volume = 0.5f;

    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);

    }
    public void Menu()
    {
        SceneManager.LoadScene(0);

    }

    public void Back()
    {
        if (SettingsScreen != null)
        {
            SettingsScreen.SetActive(false);
            
        }
        if (StartScreen != null)
        {
            StartScreen.SetActive(true);
        }
        if (PauseScreen != null)
        {
            PauseScreen.SetActive(true);
            PauseOn = true;
        }
    }

    public void Settings()
    {
        if (SettingsScreen != null)
        {
            SettingsScreen.SetActive(true);
            Time.timeScale = 0F;
        }
        if (StartScreen != null)
        {
            StartScreen.SetActive(false);
        }
        if (PauseScreen != null)
        {
            PauseScreen.SetActive(false);
            PauseOn = false;
        }

    }
    public void Pause()
    {
        if (SettingsScreen != null)
        {
            SettingsScreen.SetActive(false);
        }
        if (StartScreen != null)
        {
            StartScreen.SetActive(true);
        }
        if (PauseScreen != null)
        {
            PauseScreen.SetActive(true);
            
        }

    }
}
