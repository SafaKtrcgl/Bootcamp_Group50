using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interractable
{
    [SerializeField] private Transform drawerTransform;
    private bool isDrawerOpen = false;

    public override void OnPlayerInterract()
    {
        if (!isDrawerOpen)
        {
            drawerTransform.position += transform.forward / 2;
            isDrawerOpen = true;
        }
        else
        {
            drawerTransform.position -= transform.forward / 2;
            isDrawerOpen = false;
        }
    }
}
