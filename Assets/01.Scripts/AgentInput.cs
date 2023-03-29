using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AgentInput : MonoBehaviour
{
    public Camera MainCam;
    private RigidbodyController _rbController;
    public event Action OnPointerPositionChanged;
    public event Action OnLMouseClicked;

    [SerializeField]
    private LayerMask _isGround;
    private void Awake()
    {
        MainCam = Camera.main;
        _rbController = GetComponent<RigidbodyController>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            OnPointerPositionChanged?.Invoke();
        }
        if(Input.GetMouseButtonDown(0))
        {
            OnLMouseClicked?.Invoke();
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