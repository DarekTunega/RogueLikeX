using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterController characterController;

    protected void Awake()
    {
        DontDestroyOnLoad(this);
        characterController = GetComponent<CharacterController>();
    }

    protected void Update()
    {
        
    }
}
