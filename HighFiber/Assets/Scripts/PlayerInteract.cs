using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Image clickIndicator;
    public GameObject handPosition;
    public GameObject onMyHand;
    private RaycastHit _hit;
    private float maxDistance = 3f;
    private int canInterract = 0;

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
        if (Physics.Raycast(ray, out _hit, maxDistance) && _hit.collider.CompareTag("Interractable"))
        {
            if (!_hit.collider.gameObject.GetComponent<Interractable>().available)
            {
                if (canInterract != 2)
                {
                    canInterract = 2;
                    clickIndicator.color = Color.red;
                }
            }
            else
            {
                if (canInterract != 1)
                {
                    canInterract = 1;
                    clickIndicator.color = Color.white;
                }
            }
        }
        else
        {
            if (canInterract != 0)
            {
                canInterract = 0;
                clickIndicator.color = Color.black;
            }
        }
        
        if (canInterract == 1 && Input.GetButtonDown("Fire1"))
        {
            Interact();
        }
        else if (canInterract == 2 && Input.GetButtonDown("Fire1"))
        {
            Camera.main.transform.DOPunchRotation(Camera.main.transform.forward, 1f);
        }
    }

    private void LateUpdate()
    {
        if (onMyHand)
        {
            onMyHand.transform.DOMove(handPosition.transform.position, 0.5f);
        }
    }

    void Interact()
    {
        _hit.collider.GetComponent<Interractable>().OnPlayerInterract();
    }
}
