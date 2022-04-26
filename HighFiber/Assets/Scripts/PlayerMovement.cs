using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 2.5f;
    private Rigidbody playerRb;
    private Vector3 multiplicationVector;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * movementSpeed;
        playerRb.MovePosition(playerRb.position + direction * Time.fixedDeltaTime);
    }
}