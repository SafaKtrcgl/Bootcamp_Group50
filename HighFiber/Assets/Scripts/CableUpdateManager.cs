using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableUpdateManager : MonoBehaviour
{
    [NonSerialized] public bool cableUpdateNeeded;
    [SerializeField] private PlayerInteract playerInteract;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cableUpdateNeeded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cable tempCable;
            if (playerInteract.onMyHand && playerInteract.onMyHand.TryGetComponent(out tempCable))
            {
                playerInteract.onMyHand = null;
                tempCable.ResetPosition();
            }

            StartCoroutine("UpdateCableTransform");
        }
    }

    IEnumerator UpdateCableTransform()
    {
        yield return new WaitForSeconds(0.5f);
        cableUpdateNeeded = false;
    }
}
