using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get => _instance;
    }
    private static GameManager _instance;
    public ObserverManager observerManager;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        observerManager = new ObserverManager();
    }
}

