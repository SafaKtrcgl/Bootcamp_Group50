using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : LetterBase
{
    [SerializeField] private String letterBody;
    [SerializeField] private Answer _answer;
    [SerializeField] private GameObject canvasA4;
    [SerializeField] private Text Title;
    [SerializeField] private Text Body;

    public bool isCanvasOpen;
    
    public void OpenUpCanvas()
    {
        isCanvasOpen = true;
        Body.text = letterBody;
        Title.text = _answer.ToString();
        canvasA4.SetActive(true);
    }

    public void CloseUpCanvas()
    {
        isCanvasOpen = false;
        canvasA4.SetActive(false);
    }
}
