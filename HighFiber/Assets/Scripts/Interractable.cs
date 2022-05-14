using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    [NonSerialized]public bool available = true;
    public virtual void OnPlayerInterract()
    {
        
    }
}
