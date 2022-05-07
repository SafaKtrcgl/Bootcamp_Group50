using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Cable : Interractable
{
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private GameObject defaultParent;
    [SerializeField] private GameObject cable;
    [SerializeField] private PlayerInteract playerInteract;
    public CableHolder _cableHolder;
    public Material material;
    public override void OnPlayerInterract()
    {
        if (_cableHolder)
        {
            _cableHolder.ResetHolder();
            _cableHolder = null;
        }
        if (playerInteract.onMyHand)
        {
            playerInteract.onMyHand.GetComponent<Cable>().ResetPosition();
        }
        playerInteract.onMyHand = gameObject;
        gameObject.transform.DOMove(playerInteract.handPosition.transform.position, 0.5f);
        //cableManager.chosenCable = this.gameObject;
    }

    public void ResetPosition()
    {
        //transform.parent = defaultParent.transform;
        transform.DOLocalMove(defaultPosition, 0.5f);
        _cableHolder = null;
    }

    /*
    public void AdjustCable(GameObject cableHolder)
    {
        cable.transform.localPosition = (defaultParent.transform.localPosition + cableHolder.transform.localPosition) / 2;
        cable.transform.localScale += new Vector3(cable.transform.localScale.x, cable.transform.lossyScale.y, Vector3.Distance(defaultParent.transform.position, cableHolder.transform.position));
        cable.transform.LookAt(this.gameObject.transform);
    }
    */
}
