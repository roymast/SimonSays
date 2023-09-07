using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// GameTimer handles the time of the player and display it to the user
/// When time is over, it notify by OnTimeUp action
/// </summary>
public class GameTimer : MonoBehaviour
{
    public Action OnTimeUp;
    public int totalTime;
    float startTime;

    [SerializeField] GameManager GameManager;
    [SerializeField] TextMeshProUGUI timeText;
    public bool isTimerUp { get { return totalTime <= 0; } }

    private void Start()
    {
        totalTime = GameInit.Instance.currentConfig.GameTime;
        startTime = Time.time;
        GameManager.OnGameOver += () => enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        int timeLeft = (int)(totalTime + startTime - Time.time);
        timeText.text = "TimeLeft: " + (timeLeft).ToString();
        if (timeLeft <= 0)
        {
            OnTimeUp?.Invoke();
            enabled = false;
        }
    }    
}
