using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisplay : MonoBehaviour
{
    [SerializeField] private Material material;

    private void Start()
    {
        material.color = Color.black;
    }

    public void AddjustDisplayScreen(Color color)
    {
        Debug.Log(material.color);
        material.color += color;
        Debug.Log(material.color);
    }
}
