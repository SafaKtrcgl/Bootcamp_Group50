using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInteract _playerInteract;
    private void Update()
    {
        if (_playerInteract.onMyHand)
        {
            Letter tempLetter;
            _playerInteract.onMyHand.TryGetComponent(out tempLetter);
            if (Input.GetKeyDown(KeyCode.Tab) && tempLetter)
            {
                if (tempLetter.isCanvasOpen)
                {
                    tempLetter.CloseUpCanvas();
                }
                else
                {
                    tempLetter.OpenUpCanvas();
                }
            }
        }
    }
}
