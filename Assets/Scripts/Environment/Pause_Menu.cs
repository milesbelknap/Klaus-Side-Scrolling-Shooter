using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GameIsPaused = false;
    public GameObject settingMenu;
    public GameObject canvas;
    public GameObject exitSettings;
    public GameObject fadeIn;

    public void Awake()
    {
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
    }

    public void Start()
    {
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        canvas.SetActive(false);
        Destroy(fadeIn);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        canvas.SetActive(true);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level_Selector");
        Time.timeScale = 1f;
    }

    public void Setting()
    {
        settingMenu.SetActive(true);
        exitSettings.SetActive(true);
    }

    public void ExitSetting()
    {
        settingMenu.SetActive(false);
        exitSettings.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
