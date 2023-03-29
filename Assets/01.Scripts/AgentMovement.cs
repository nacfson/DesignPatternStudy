using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private AgentInput _agentInput;
    private CharacterController _controller;
    private float _playerSpeed =5f;
    private Vector3 _movementVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _agentInput = GetComponent<AgentInput>();
        _agentInput.OnLMouseClicked += SetMovementVelocity;
        _agentInput.OnLMouseClicked += LookRotation;
    }

    public void SetMovementVelocity(Vector3 value)
    {
        _movementVelocity = value;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveSpeed = 5f; // 이동 속도
        Vector3 direction = (_movementVelocity - transform.position).normalized;
        _controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    private void LookRotation(Vector3 dir)
    {
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

}
