using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementNonAimed : MonoBehaviour
{
    [FormerlySerializedAs("_controller")] [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;
    [SerializeField] private Transform cam;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;
    private Animator _animator;
    public PlayerAim playerAim; // Reference to the PlayerAim script


    [SerializeField] private float mouseSensitivity = 3.0f; // Sensitivity for mouse movement
    [SerializeField] private float minAimAngle = -20.0f; // Clamped angle for aiming down
    [SerializeField] private float maxAimAngle = 20.0f; // Clamped angle for aiming up

    private bool isAiming = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isAiming = IsAiming();

        if (!isAiming)
        {
            HandleNonAiming();
        }
        else
        {
            HandleAiming();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private bool IsAiming()
    {
        // You can implement your aiming logic here, for example, checking if the right mouse button is held down.
        return Input.GetMouseButton(1);
    }

    private void HandleNonAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float inputSpeed = Mathf.Clamp01(direction.magnitude);
        _animator.SetFloat("Speed", inputSpeed);

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        HandleMovement(direction);
        HandlePlayerRotation();
    }

    private void HandleAiming()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        float verticalRotation = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, minAimAngle, maxAimAngle);

        // Modify the player's rotation based on mouse input.
        transform.Rotate(Vector3.up * horizontalRotation);

        if (horizontalRotation != 0)
        {
            // Modify the camera's rotation based on the horizontal rotation while aiming.
            cam.Rotate(Vector3.up * horizontalRotation);
        }
    }

    private void HandleMovement(Vector3 direction)
    {
        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * (speed * Time.deltaTime));
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    private void HandlePlayerRotation()
    {
        if (playerAim.isAimed)
        {
            // Modify the player's rotation based on your mouse input when not aiming.
            float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(Vector3.up * horizontalRotation);
        }
    }
}
