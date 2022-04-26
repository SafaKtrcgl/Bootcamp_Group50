using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject handPosition;
    public GameObject onMyHand;
    private RaycastHit _hit;
    private float maxDistance = 3f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Interact();
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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
        if (Physics.Raycast(ray, out _hit, maxDistance) && _hit.collider.CompareTag("Interractable"))
        {
            _hit.collider.GetComponent<Interractable>().OnPlayerInterract();
        }
        else
        {
            Debug.Log("no hit");
        }
    }
}
