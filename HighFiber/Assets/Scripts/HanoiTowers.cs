using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTowers : Interractable
{
    public GameObject[] hanoisEquipped;
    public Stack<GameObject> hanois = new Stack<GameObject>();
    private PlayerInteract _playerInteract;

    private void Start()
    {
        _playerInteract = FindObjectOfType<PlayerInteract>().GetComponent<PlayerInteract>();
        for (int i = 0; i < hanoisEquipped.Length; i++)
        {
            hanois.Push(hanoisEquipped[i]);
        }
    }

    public override void OnPlayerInterract()
    {
        if (!_playerInteract.onMyHand)
        {
            _playerInteract.onMyHand = OnPLayerInteractToPop();
            if (_playerInteract.onMyHand)
            {
                _playerInteract.onMyHand.gameObject.GetComponent<Rigidbody>().useGravity = false;
                _playerInteract.onMyHand.gameObject.GetComponent<BoxCollider>().enabled = false;
                _playerInteract.onMyHand.transform.parent = _playerInteract.handPosition.transform;
            }
        }
        else
        {
            OnPlayerInteractToPush(_playerInteract.onMyHand);
            _playerInteract.onMyHand = null;
        }
    }

    public GameObject OnPLayerInteractToPop()
    {
        if (hanois.Count != 0)
        {
            return hanois.Pop();
        }
        return null;
    }

    public void OnPlayerInteractToPush(GameObject cube)
    {
        cube.transform.parent = gameObject.transform;
        cube.transform.localPosition = Vector3.up;
        cube.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cube.gameObject.GetComponent<Rigidbody>().useGravity = true;
        cube.gameObject.GetComponent<BoxCollider>().enabled = true;
        hanois.Push(cube);
    }
}
