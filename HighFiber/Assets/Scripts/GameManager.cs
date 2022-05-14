using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool _isGameActive = true;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscPressed(_isGameActive);
        }
    }

    void OnEscPressed(bool gameState)
    {
        if (gameState)
        {
            Time.timeScale = 0;
            _isGameActive = false;
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
}
