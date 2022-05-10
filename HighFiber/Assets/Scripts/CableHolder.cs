using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CableHolder : Interractable
{
    [SerializeField]private float multiplierValue;
    public GameObject currentCable = null;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private Material material;
    private Vector3 _holdPosition = new Vector3(0f, 0.75f, 0f);
    [SerializeField] private ScreenDisplay screenDisplay;

    private void Start()
    {
        material.color = Color.white;
    }

    public void ResetHolder()
    {
        currentCable = null;
        screenDisplay.AddjustDisplayScreen(material.color * -multiplierValue);
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
            material.color = currentCable.GetComponent<Cable>().material.color * multiplierValue;
            screenDisplay.AddjustDisplayScreen(material.color * multiplierValue);
            playerInteract.onMyHand = null;
        }
    }
}
