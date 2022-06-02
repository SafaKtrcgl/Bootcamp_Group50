using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private HanoiTowers[] Shelves;
    
    public void CheckIfDone()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Shelves[i].hanois.Count != 0)
            {
                return;
            }
        }
        ShelfDone();
    }

    private void ShelfDone()
    {
        for (int i = 0; i < Shelves.Length; i++)
        {
            Shelves[i].available = false;
        }
        _gameManager.OnPuzzleComplete();
    }
}
