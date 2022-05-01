using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Drawer : Interractable
{
    [SerializeField] private Transform drawerTransform;
    private bool isDrawerOpen = false;

    public override void OnPlayerInterract()
    {
        if (!isDrawerOpen)
        {
            drawerTransform.DOMove(drawerTransform.position - drawerTransform.forward / 2, 0.5f);
            isDrawerOpen = true;
        }
        else
        {
            drawerTransform.DOMove(drawerTransform.position + drawerTransform.forward / 2, 0.5f);
            isDrawerOpen = false;
        }
    }
}
