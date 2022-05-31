using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorHandle : Interractable
{
    [SerializeField] private Transform doorTransform;
    [SerializeField] private bool toInside;
    [SerializeField] private Door door;
    private Vector3 doorOpensTo;

    private void Start()
    {
        if (toInside)
        {
            doorOpensTo = new Vector3(0f, -90f, 0f);
        }
        else
        {
            doorOpensTo = new Vector3(0f, 90f, 0f);
        }
    }

    public override void OnPlayerInterract()
    {
        Debug.Log("selam");
        if (door.isDoorOpen)
        {
            doorTransform.DORotate(doorTransform.rotation.eulerAngles - doorOpensTo, 0.5f);
            door.isDoorOpen = false;
        }
        else
        {
            doorTransform.DORotate(door.transform.rotation.eulerAngles + doorOpensTo, 0.5f);
            door.isDoorOpen = true;
        }
    }
}
