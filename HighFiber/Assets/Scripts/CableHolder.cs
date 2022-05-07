using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CableHolder : Interractable
{
    public GameObject currentCable;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private Material material;
    private Vector3 _holdPosition = new Vector3(0f, 0.75f, 0f);

    private void Start()
    {
        ResetHolder();
    }

    public void ResetHolder()
    {
        currentCable = null;
        material.color = Color.white;
    }

    public override void OnPlayerInterract()
    {
        if (playerInteract.onMyHand)
        {
            if (currentCable)
            {
                currentCable.GetComponent<Cable>().ResetPosition();
                currentCable = null;
            }
            currentCable = playerInteract.onMyHand;
            //currentCable.transform.parent = gameObject.transform;
            currentCable.GetComponent<Cable>()._cableHolder = this;
            currentCable.transform.DOMove(transform.position + Vector3.up * .1f, 0.5f);
            //currentCable.GetComponent<Cable>().AdjustCable(this.gameObject);
            material.color = currentCable.GetComponent<Cable>().material.color;
            playerInteract.onMyHand = null;
        }
    }
}
