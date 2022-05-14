using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SimonSaysNodes : Interractable
{
    [SerializeField] private SimonSaysManager simonSaysManager;
    [SerializeField] private int simonNodeIndex;
    [SerializeField] private GameObject light;
    public override void OnPlayerInterract()
    {
        if (available)
        {
            StartCoroutine(Blink(light));
            simonSaysManager.usersPattern[simonSaysManager.userInputIndex] = simonNodeIndex;
            simonSaysManager.userInputIndex++;
            if (simonSaysManager.userInputIndex == simonSaysManager.usersPattern.Length)
            {
                simonSaysManager.CheckInputsValidity();
            }
        }
    }

    IEnumerator Blink(GameObject light)
    {
        light.SetActive(true);
        yield return new WaitForSeconds(.1f);
        light.SetActive(false);
    }
}
