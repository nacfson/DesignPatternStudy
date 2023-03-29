using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    private AgentInput _agentInput;
    private Rigidbody _rigid;
    Vector3 _targetPos = Vector3.zero;
    public bool canMove;

    void Awake()
    {
        _agentInput = GetComponent<AgentInput>();
        _rigid = GetComponent<Rigidbody>();
        //_agentInput.OnPointerPositionChanged += Move;
        canMove = false;
        //_agentInput.OnPointerPositionChanged += CalculatePos;
    }
    void Update()
    {
        if(canMove)
        {
            RigidbodyMove();
        }
    }

    private void RigidbodyMove()
    {
        float moveSpeed = 5f;
        Vector3 dir = _targetPos - transform.position;
        _rigid.MovePosition(transform.position + dir *moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, _targetPos) < 0.1f)
        {
            canMove = false;
        }
    }
    private void CalculatePos()
    {
        _targetPos = _agentInput.GetMouseWorldPoint() + new Vector3(0, 1, 0);
        canMove = true;
    }
}
