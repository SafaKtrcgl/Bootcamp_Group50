using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableUpdateManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [NonSerialized] public bool cableUpdateNeeded;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private CableHolder[] allHolders;
    //[SerializeField] private CableHolder[] holdersRequired;
    [SerializeField] private GameObject[] cablesRequired;
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

    public void CheckIfDone()
    {
        for (int i = 0; i < cablesRequired.Length; i++)
        {
            if (allHolders[i].currentCable != cablesRequired[i])
            {
                return;
            }
        }
        CablesDone();
    }

    private void CablesDone()
    {
        for (int i = 0; i < cablesRequired.Length; i++)
        {
            cablesRequired[i].GetComponent<Cable>().available = false;
        }

        for (int i = 0; i < allHolders.Length; i++)
        {
            allHolders[i].available = false;
        }
        _gameManager.OnPuzzleComplete();
    }
}
