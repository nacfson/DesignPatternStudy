using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    private AgentInput _agentInput;
    [SerializeField]
    private float _rayDistance = 10f;
    [SerializeField]
    private float _forcePower;
    private LineRenderer _line;
    private Transform _basePos;

    void Awake()
    {
        _agentInput =GetComponent<AgentInput>();
        _line = GetComponent<LineRenderer>();
        _basePos = transform.Find("BasePosition").GetComponent<Transform>();

        _agentInput.OnLMouseClicked += LookRotation;
        _agentInput.OnLMouseClicked += ShootRay;
    }


    private void OnDisable()
    {
        _agentInput.OnLMouseClicked -= LookRotation;
        _agentInput.OnLMouseClicked -= ShootRay;
    }

    IEnumerator DrawLine(float delayTime,Vector3 hitPos)
    {
        _line.enabled = true;
        _line.SetPosition(0,_basePos.position);
        _line.SetPosition(1,hitPos);
        yield return new WaitForSeconds(delayTime);
        _line.enabled = false;
    }

    private void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool result = Physics.Raycast(ray,out hit,_rayDistance);
        if(result)
        {
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                StopAllCoroutines();
                StartCoroutine(DrawLine(0.1f,hit.point));
                // Rigidbody rigid = hit.collider.GetComponent<Rigidbody>();
                // Vector3 forceDirection = hit.collider.transform.position - transform.position;
                // rigid.AddForce(forceDirection * _forcePower,ForceMode.Impulse);
                if(hit.collider.GetComponentInParent<CrashBlock>() != null)
                {
                    CrashBlock cb = hit.collider.GetComponentInParent<CrashBlock>();
                    cb.ForceObject();
                }
            }
        }
    }
    //왜 dir 을 0 으로 했을 때 정확한 방향으로 돌아갈까
    private void LookRotation()
    {
        Vector3 dir = _agentInput.GetMouseWorldPoint();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position ,transform.forward * _rayDistance);
    }
}

