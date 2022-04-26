using System;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class CameraRotation : MonoBehaviour
{
    public Transform playerBody;
    
    private float mouseSense = 100f;
    private float xRotation = 0f;
    private float mouseX = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(0f, mouseX, 0f);
    }
}