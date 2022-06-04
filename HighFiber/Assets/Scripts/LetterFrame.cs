using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LetterFrame : Interractable
{ 
    [SerializeField] private Letter myLetter;
    [SerializeField] private PlayerInteract _playerInteract;
    //[SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private LetterPuzzle letterPuzzle;

    public override void OnPlayerInterract()
    {
        if (_playerInteract.onMyHand)
        {
            Letter trialLetter;
            _playerInteract.onMyHand.TryGetComponent(out trialLetter);
            if (trialLetter == myLetter.GetComponent<Letter>())
            {
                trialLetter.CloseUpCanvas();
                available = false;
                _playerInteract.onMyHand.transform.parent = null;
                _playerInteract.onMyHand.gameObject.transform.DOMove(transform.position, 0.5f);
                _playerInteract.onMyHand.gameObject.transform.DORotate(rotation, 0.5f);
                _playerInteract.onMyHand = null;
                letterPuzzle.CheckIfDone();
            }
            else
            {
                Camera.main.transform.DOPunchRotation(Camera.main.transform.forward, 1f);
            }
        }
        else
        {
            Camera.main.transform.DOPunchRotation(Camera.main.transform.forward, 1f);
        }
    }
}
