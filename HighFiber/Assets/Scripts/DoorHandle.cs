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
    public override void OnPlayerInterract()
    {
        if (toInside)
        {
            doorOpensTo = new Vector3(0f, 90f, 0f);
        }
        else
        {
            doorOpensTo = new Vector3(0f, -90f, 0f);
        }
        if (door.isDoorOpen)
        {
            doorTransform.DORotate(new Vector3(0f, -180f, 0f), 0.5f);
            door.isDoorOpen = false;
        }
        else
        {
            doorTransform.DORotate(doorOpensTo, 0.5f);
            door.isDoorOpen = true;
        }
    }
}
