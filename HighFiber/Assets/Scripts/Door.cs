using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interractable
{
    [SerializeField] private Transform doorTransform;
    private bool _isDoorOpen = false;
    public override void OnPlayerInterract()
    {
        if (!_isDoorOpen)
        {
            doorTransform.rotation = Quaternion.Euler(0f, -90f, 0f);
            _isDoorOpen = true;
        }
        else
        {
            doorTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _isDoorOpen = false;
        }
    }
}
