using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAim : MonoBehaviour
{
    public float aimFOV = 30f; // Adjust this value for your desired FOV when aiming
    public float normalFOV = 60f; // Adjust this value for your normal FOV

    public CinemachineFreeLook thirdPersonCamera;
    public CinemachineVirtualCamera aimCamera;

    public bool isAimed = false;

    private void Start()
    {
     isAimed = false;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isAimed)
        {
            // Switch to the aim camera by enabling it and disabling the FreeLook camera.
            aimCamera.gameObject.SetActive(true);
            thirdPersonCamera.gameObject.SetActive(false);

            // Adjust the Field of View of the FreeLook camera to simulate zoom.
            thirdPersonCamera.m_Lens.FieldOfView = aimFOV;
            isAimed = true;
        }
        else if (Input.GetMouseButtonDown(1) && isAimed)
        {
            // Switch back to the FreeLook camera by enabling it and disabling the aim camera.
            thirdPersonCamera.gameObject.SetActive(true);
            aimCamera.gameObject.SetActive(false);

            // Reset the Field of View to the normal FOV.
            thirdPersonCamera.m_Lens.FieldOfView = normalFOV;
            isAimed = false;
        }
    }
}