using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    static Singleton<T> _instance;
    protected static readonly object _syncLock = new object();

    protected virtual void Awake()
    {
        bool destroyCurrentInstance = true;

        if (_instance == null)
        {
            lock (_syncLock)
            {
                if (_instance == null)
                {
                    _instance = this;
                    DontDestroyOnLoad(gameObject);
                    destroyCurrentInstance = false;
                }
            }
        }

        if (destroyCurrentInstance)
        {
            Destroy(gameObject);
            return;
        }
    }

    public static T Instance
    {
        get 
        {
            return GetInstance() as T;
        }
    }

    static Singleton<T> GetInstance()
    {
        return _instance;
    }
}

