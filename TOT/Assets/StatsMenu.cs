using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    public bool StatsMenuOpen;

    public GameObject statsMenuUI;

    void Start()
    {
        CloseStats(); // Ensure the game starts with the stats menu closed
        StatsMenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !StatsMenuOpen) // Change key to "I"
        {
            // if (StatsMenuOpen)
            // {
            //     CloseStats();
            // }
            // else
            // {
            //     OpenStats();
            // }
            OpenStats();
        }
        else if(Input.GetKeyDown(KeyCode.I) && StatsMenuOpen)
        {
            CloseStats();
        }
    }

    public void OpenStats()
    {
        statsMenuUI.SetActive(true);  // Show the stats menu UI
        Time.timeScale = 0f;          // Optionally stop time, if needed
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StatsMenuOpen = true;         // Update the state
    }

    public void CloseStats()
    {
        statsMenuUI.SetActive(false); // Hide the stats menu UI
        Time.timeScale = 1f;          // Resume time, if paused
        StatsMenuOpen = false;        // Update the state
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;       
    }
}
