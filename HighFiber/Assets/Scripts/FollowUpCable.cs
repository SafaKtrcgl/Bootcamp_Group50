using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUpCable : MonoBehaviour
{
    [SerializeField] private GameObject plug;
    [SerializeField] private CableUpdateManager _cableUpdateManager;
    private void Update()
    {
        if (_cableUpdateManager.cableUpdateNeeded)
        {
            transform.LookAt(plug.gameObject.transform);
            transform.localPosition = plug.transform.localPosition / 2;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, plug.transform.localPosition.magnitude);
        }
    }
}
