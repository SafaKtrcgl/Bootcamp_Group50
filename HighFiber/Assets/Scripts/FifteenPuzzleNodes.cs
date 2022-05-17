using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifteenPuzzleNodes : Interractable
{
    public int[] location = new int[2];
    [SerializeField]private FifteenPuzzle _fifteenPuzzle;
    [SerializeField] private int[] locationMeantToBe = new int[2];

    public override void OnPlayerInterract()
    {
        if (available)
        {
            _fifteenPuzzle.CheckAvailability(gameObject, location);
        }
    }

    public bool IsInRightPlace()
    {
        return location[0] == locationMeantToBe[0] && location[1] == locationMeantToBe[1];
    }
}
