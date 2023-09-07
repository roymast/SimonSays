using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SingletonBehaviour make every class the derives from it a singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonBehaviour<T> : MonoBehaviour where T: SingletonBehaviour<T>
{
    public static T Instance { get; protected set; }
 
    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            Instance = (T)this;
        }
    }
}
