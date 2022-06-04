using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LetterFrame[] letterFrame;
    public void CheckIfDone()
    {
        for (int i = 0; i < letterFrame.Length; i++)
        {
            if (letterFrame[i].available)
            {
                return;
            }
        }
        Done();
    }

    private void Done()
    {
        gameManager.OnPuzzleComplete();
    }
}
