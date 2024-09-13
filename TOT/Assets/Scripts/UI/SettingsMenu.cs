// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SettingsMenu : MonoBehaviour
// {
//     public void SetVolume (float volume)
//     {
//         Debug.Log(volume);
//     }

//     public void MBack()
//     {
//         Time.timeScale = 1f;
//         SceneManager.LoadScene("MAINMENU");
//     }

//     public void JBack()
//     {
//         Time.timeScale = 1f;
//         SceneManager.LoadScene("Jack");
//     }

//     public void CBack()
//     {
//         Time.timeScale = 1f;
//         SceneManager.LoadScene("Calib");
//     }

// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    void Start(){
        
    }
    // Update is called once per frame
    void Update() {

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMAINMENU()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MAINMENU");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void LoadSETTINGSMENU()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SETTINGSMENU");
    }

    public void SettingsMenuOpen()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetingsMenuClose()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
