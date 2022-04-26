using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FifteenPuzzle : MonoBehaviour
{
    [SerializeField]private int[] positionOfTheSpace;
    [SerializeField] private GameObject space;

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
        obj.transform.position = space.transform.position;
        space.transform.position = temp;
    }

    private void UpdateArrays(GameObject obj, int[] clickLocation)
    {
        int[] temp = obj.GetComponent<FifteenPuzzleNodes>().location;
        obj.GetComponent<FifteenPuzzleNodes>().location = positionOfTheSpace;
        positionOfTheSpace = temp;
    }
}
