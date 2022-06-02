using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject a4UI;
    [SerializeField] private Interractable[] doorHandles;
    private bool _isGameActive = true;
    private int currentLevel = 0;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscPressed(_isGameActive);
        }
    }

    public void OnEscPressed(bool gameState)
    {
        if (gameState)
        {
            Time.timeScale = 0;
            _isGameActive = false;
            a4UI.SetActive(false);
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            _isGameActive = true;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OnPuzzleComplete()
    {
        doorHandles[currentLevel].available = true;
        currentLevel++;
        Debug.Log("**** YAY");
    }
}
