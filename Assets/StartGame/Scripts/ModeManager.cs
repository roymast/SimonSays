using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance { get; private set; }
    public static string levelSelected { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void SelectLevel(string level)
    {
        SceneManager.LoadScene("Game");
    }
}
