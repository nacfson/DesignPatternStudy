using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Core.Define;
public class AgentInput : MonoBehaviour
{
    //private RigidbodyController _rbController;
    public event Action OnRightClicked;
    public event Action<Vector3> OnLMouseClicked;

    [SerializeField]
    private LayerMask _isGround;
    private void Awake()
    {
        //_rbController = GetComponent<RigidbodyController>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            OnRightClicked?.Invoke();
        }
        if(Input.GetMouseButtonDown(0))
        { 
            OnLMouseClicked?.Invoke(GetMouseWorldPoint());
        }
    }


    public Vector3 GetMouseWorldPoint()
    {
        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        bool result = Physics.Raycast(ray,out hit,MainCam.farClipPlane,_isGround);
        return result == true ? hit.point: Vector3.zero;
    }
}
