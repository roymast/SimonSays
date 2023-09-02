using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCommandLineArgs : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField]
    TextAsset editorArgumentFile = null;
#endif
    string[] args;
    // Start is called before the first frame update
    void Awake()
    {
        if (args == null || args.Length == 0)
            InitArgs();
    }       
    void InitArgs()
    {
#if UNITY_EDITOR
        if (editorArgumentFile != null)
            args = editorArgumentFile.text.Split();
#else
        args = Environment.GetCommandLineArgs();
#endif
    }
    public string GetArgumentByKey(string argumentKey)
    {
        if (args == null || args.Length == 0)
            InitArgs();

        for (int i = 0; i < args.Length-1; i++)
        {            
            if (args[i] == argumentKey)
                return args[i+1];
        }
        Debug.LogError("could not found argument: " + argumentKey);
        return string.Empty;
    }        
    public string GetArgumentByIndex(int index)
    {
        if (args == null || args.Length == 0)
            InitArgs();
        if (args == null || args.Length == 0)
            return "";
        return args[index];
    }
}
