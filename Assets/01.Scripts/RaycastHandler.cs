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
    [SerializeField]
    private Transform _basePos;
    private bool _canShoot = true;

    void Awake()
    {
        _agentInput =GetComponent<AgentInput>();
        _line = GetComponent<LineRenderer>();
        _basePos = transform.Find("Cube").transform.Find("BasePosition");
        _agentInput.OnRightClicked += ShootRay;
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
        if(_canShoot == false) return;
        StartCoroutine(ShootingDelay());
        LookRotation();
        Ray ray = new Ray(_basePos.position, _basePos.forward);
        RaycastHit hit;
        bool result = Physics.Raycast(ray,out hit,_rayDistance);
        if(result)
        {
            if(hit.collider != null)
            {
                StartCoroutine(DrawLine(0.05f,hit.point));
                if(hit.collider.GetComponent<CubeHP>() != null)
                {
                    hit.collider.GetComponent<CubeHP>().Damage(1);
                }
            }
        }
    }

    IEnumerator ShootingDelay()
    {
        _canShoot = false;
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }

    //왜 dir 을 0 으로 했을 때 정확한 방향으로 돌아갈까
    private void LookRotation()
    {
        Vector3 dir = _agentInput.GetMouseWorldPoint();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_basePos.position, _basePos.forward* _rayDistance);
    }
}

