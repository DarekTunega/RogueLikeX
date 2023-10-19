using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_RobotFollow : MonoBehaviour
{
    public Transform playerPosition;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log(_agent.speed);
        _agent.destination = playerPosition.position;
    }
}
