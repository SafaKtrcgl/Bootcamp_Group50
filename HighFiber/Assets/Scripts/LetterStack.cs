using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterStack : Interractable
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private PlayerInteract _playerInteract;
    private Stack<GameObject> _letters = new Stack<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _gameObjects.Length; i++)
        {
            _letters.Push(_gameObjects[i]);
        }
    }

    public override void OnPlayerInterract()
    {
        if (!_playerInteract.onMyHand)
        {
            _playerInteract.onMyHand = _letters.Pop();
            _playerInteract.onMyHand.GetComponent<Letter>().OpenUpCanvas();
        }
        if (_letters.Count == 0)
        {
            available = false;
        }
    }

    
}
