using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HanoiTowers : Interractable
{
    public GameObject[] hanoisEquipped;
    public Stack<GameObject> hanois = new Stack<GameObject>();
    private PlayerInteract _playerInteract;
    private Vector3 positionOffSetPerBook = new Vector3(0.07f, 0f, 0f);
    private Vector3 bookPosition = new Vector3(-0.45f, -0.05f, -0.1f);

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
                //_playerInteract.onMyHand.gameObject.GetComponent<BoxCollider>().enabled = false;
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
        //cube.transform.localPosition = bookPosition + positionOffSetPerBook * hanois.Count;
        cube.transform.DOLocalMove(bookPosition + positionOffSetPerBook * hanois.Count, 0.5f);
        cube.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //cube.gameObject.GetComponent<BoxCollider>().enabled = true;
        hanois.Push(cube);
    }
}
