using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene switcher is switch between scenes.
/// It is possible to just use SceneManager.LoadScene(), but it is more organized this way
/// </summary>
public class SceneSwitcher
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
}
