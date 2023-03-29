// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Controller : MonoBehaviour
// {
//     private float _speed = 3f;
//     private AgentInput _agentInput;
//     private Rigidbody _rigid;
//     Vector3 _targetPos = Vector3.zero;

//     void Awake()
//     {
//         _agentInput = GetComponent<AgentInput>();
//         _rigid = GetComponent<Rigidbody>();
//         _agentInput.OnPointerPositionChanged += Move;
//         _agentInput.OnPointerPositionChanged += CalculatePos;
//     }
//     void Update()
//     {
//         RigidbodyMove();
//     }

//     private void RigidbodyMove()
//     {
        
//     }
//     private void CalculatePos()
//     {
//         _targetPos = _agentInput.GetMouseWorldPoint() + new Vector3(0, 1, 0);
//     }

//     private void Move()
//     {
//         //Vector3 dir = _agentInput.GetMouseWorldPoint() - transform.position;
//         StopAllCoroutines();
//         Vector3 dir = _agentInput.GetMouseWorldPoint() + new Vector3(0,1,0);
//         StartCoroutine(MoveCor(dir));
//     }

//     IEnumerator MoveCor(Vector3 targetPos)
//     {
//         while(transform.position != targetPos)
//         {
//             Debug.Log(targetPos);
//             transform.position = Vector3.MoveTowards(transform.position,targetPos,_speed * Time.deltaTime);
//             yield return null;
//         }
//     }
// }
