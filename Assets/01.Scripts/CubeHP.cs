using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHP : MonoBehaviour
{
    public int hp = 3;

    public void Damage(int damage)
    {
        hp -= damage;
        if(hp<=0)
        {
            DeadProcess();
        }
    }
    private void DeadProcess()
    {
        Destroy(gameObject);
    }
}
