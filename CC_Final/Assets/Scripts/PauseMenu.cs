using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;
    public GameObject volumeMenuUI;


    // Update is called once per frame
    void Update()
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




    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        // This is to bring the pause button back on the screen:
        pauseButtonUI.SetActive(true);
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // This is to hide the pause button from the pause menu:
        pauseButtonUI.SetActive(false);
    }


    public void LoadVolumeMenu()
    {
        // Debug.Log("Loading menu.....");
        volumeMenuUI.SetActive(true);
        // SceneManager.LoadScene(4);
        Time.timeScale = 1f;  //Reset timescale to normal

    }


    public void QuitGame()
    {
        Debug.Log("Quiting game.....");
        Application.Quit();
    }


}









