using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private AgentInput _agentInput;
    private CharacterController _controller;
    private float _playerSpeed =5f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _agentInput = GetComponent<AgentInput>();
        _agentInput.OnLMouseClicked += Move;
    }

    private void Move(Vector3 dir)
    {
        StopAllCoroutines();
        StartCoroutine(MoveCor(dir));
    }

    IEnumerator MoveCor(Vector3 dir)
    {
        while(Vector3.Distance(transform.position, dir) > 0.1f)
        {
            Vector3 direction = dir-transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
            _controller.Move(transform.forward * Time.deltaTime * _playerSpeed);
            yield return null;
        }
    }
}
