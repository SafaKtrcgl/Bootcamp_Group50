using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimonSaysManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] simonSaysLights;
    private int _maxLengthOfPattern = 4;
    private int _currentLengthOfPattern = 0;
    private int[] _truePattern = new int[4];
    [NonSerialized] public int[] usersPattern = new int[4];
    [NonSerialized]public int userInputIndex;
    private bool isSolved = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!isSolved)
        {
            CreatePattern();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        userInputIndex = 0;
        Array.Clear(usersPattern, 0, usersPattern.Length);
        ResetPattern();
    }

    void ResetPattern()
    {
        Array.Clear(_truePattern, 0, _truePattern.Length);
        Array.Clear(usersPattern, 0, usersPattern.Length);
        _currentLengthOfPattern = 0;
    }

    void CreatePattern()
    {
        CreateRandomIndex();
    }

    void CreateRandomIndex()
    {
        if (_currentLengthOfPattern != _maxLengthOfPattern)
        {
            int index = Random.Range(0, simonSaysLights.Length);
            _truePattern[_currentLengthOfPattern] = index;
            _currentLengthOfPattern++;
            StartCoroutine(FlashSSLight(index));
        }
    }

    IEnumerator FlashSSLight(int index)
    {
        yield return new WaitForSeconds(.25f);
        simonSaysLights[index].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        simonSaysLights[index].SetActive(false);
        CreateRandomIndex();
    }

    public void CheckInputsValidity()
    {
        for (int i = 0; i < _truePattern.Length; i++)
        {
            if (usersPattern[i] != _truePattern[i])
            {
                Array.Clear(usersPattern, 0, usersPattern.Length);
                Array.Clear(_truePattern, 0, _truePattern.Length);
                userInputIndex = 0;
                return;
            }
        }
        SimonsDone();
    }

    private void SimonsDone()
    {
        isSolved = true;
        foreach (GameObject light in simonSaysLights)
        {
            light.GetComponentInParent<SimonSaysNodes>().available = false;
        }
        gameManager.OnPuzzleComplete();
    }
}
