using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameManager _gameManager;
    
    public void OnResumeButtonClicked()
    {
        _gameManager.OnEscPressed(false);
    }
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
