using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashBlock : MonoBehaviour
{
    GameObject[] meshArray;

    private void Awake()
    {
        meshArray = new GameObject[transform.childCount];
        for(int i =0 ; i< transform.childCount; i++)
        {
            meshArray[i] = transform.GetChild(i).gameObject;    
            meshArray[i].GetComponent<Rigidbody>().useGravity = false;
            Debug.Log(meshArray[i].name);
        }
    }

    public void ForceObject()
    {
        float forcePower = 5f;
        foreach(var i in meshArray)
        {
            i.GetComponent<Rigidbody>().useGravity = true;
            i.GetComponent<Rigidbody>().AddForce(transform.forward * forcePower);
        }
    }
}
