using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Transform groundCheckTransform;
    [SerializeField]private LayerMask groundMask;
    private CharacterController _controller;
    private Vector3 _velocityForGravity;
    private float movementSpeed = 5f;
    private float jumpHeight = 3f;
    private float _gravity = -19.62f;
    private float _groundDistance = .25f;
    private bool _isGrounded;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheckTransform.position, _groundDistance, groundMask);
        if (_isGrounded && _velocityForGravity.y < 0)
        {
            _velocityForGravity.y = -3f;
        }
        
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movementVec = (transform.right * inputX + transform.forward * inputZ);
        if (movementVec.magnitude > 1)
        {
            movementVec = movementVec.normalized;
        }
        movementVec *= movementSpeed;
        _controller.Move(movementVec * Time.deltaTime);
        
        _velocityForGravity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocityForGravity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocityForGravity.y = Mathf.Sqrt(jumpHeight * -2 * _gravity);
        }
    }
}