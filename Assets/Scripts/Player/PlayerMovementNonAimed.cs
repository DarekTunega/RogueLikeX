using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerMovementNonAimed : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Transform cam;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Animator _animator;
    public PlayerAim playerAim;

    [SerializeField] private float mouseSensitivity = 3.0f;
    
    private bool _isAiming = false;
    private float turnSmoothVelocity;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isAiming = IsAiming();

        if (!_isAiming)
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (cam.transform.forward * vertical + cam.transform.right * horizontal).normalized;

        controller.Move(moveDirection * speed * Time.deltaTime);
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
            float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(Vector3.up * horizontalRotation);
        }
    }
}
