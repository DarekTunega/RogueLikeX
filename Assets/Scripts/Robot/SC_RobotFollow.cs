using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_RobotFollow : MonoBehaviour
{
    public Transform playerPosition;
    private NavMeshAgent _agent;
    public float distance;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(_agent.destination, playerPosition.position) > distance)
        {
            _agent.speed = 4;
            _agent.destination = playerPosition.position;
        }
        
    }
}
