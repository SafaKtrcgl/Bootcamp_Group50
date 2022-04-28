using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Image clickIndicator;
    public GameObject handPosition;
    public GameObject onMyHand;
    private RaycastHit _hit;
    private float maxDistance = 3f;
    private bool canInterract = false;

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
        if (Physics.Raycast(ray, out _hit, maxDistance) && _hit.collider.CompareTag("Interractable"))
        {
            if (!canInterract)
            {
                clickIndicator.color = Color.white;
            }
            canInterract = true;
            
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }
        else
        {
            if (canInterract)
            {
                clickIndicator.color = Color.black;
            }
            canInterract = false;
        }
    }

    private void LateUpdate()
    {
        if (onMyHand)
        {
            onMyHand.transform.position = Vector3.Lerp(onMyHand.transform.position, handPosition.transform.position, 1f);
        }
    }

    void Interact()
    {
        _hit.collider.GetComponent<Interractable>().OnPlayerInterract();
    }
}
