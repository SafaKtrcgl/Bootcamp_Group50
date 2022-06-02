using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FifteenPuzzle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField]private int[] positionOfTheSpace;
    [SerializeField] private GameObject space;
    [SerializeField] private FifteenPuzzleNodes[] nodesArray = new FifteenPuzzleNodes[15];

    public void CheckAvailability(GameObject clickedObject, int[] clickLocation)
    {
        if (Mathf.Abs(clickLocation[0] - positionOfTheSpace[0]) + Mathf.Abs(clickLocation[1] - positionOfTheSpace[1]) == 1)
        {
            SwapTiles(clickedObject);
            UpdateArrays(clickedObject, clickLocation);
        }
    }

    private void SwapTiles(GameObject obj)
    {
        Vector3 temp = obj.transform.position;
        obj.transform.DOMove(space.transform.position, 0.5f);
        space.transform.position = temp;
    }

    private void UpdateArrays(GameObject obj, int[] clickLocation)
    {
        int[] temp = obj.GetComponent<FifteenPuzzleNodes>().location;
        obj.GetComponent<FifteenPuzzleNodes>().location = positionOfTheSpace;
        positionOfTheSpace = temp;
        CheckIfSolved();
    }

    private void CheckIfSolved()
    {
        for (int i = 0; i < nodesArray.Length; i++)
        {
            if (!nodesArray[i].IsInRightPlace())
            {
                return;
            }
        }

        FifteenPuzzleDone();
    }

    private void FifteenPuzzleDone()
    {
        for (int i = 0; i < nodesArray.Length; i++)
        {
            nodesArray[i].available = false;
        }
        gameManager.OnPuzzleComplete();
    }
}
