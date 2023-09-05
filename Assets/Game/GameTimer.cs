using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameTimer : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    public Action OnTimeUp;
    [SerializeField] TextMeshProUGUI timeText;
    public int totalTime;
    float startTime;
    public bool isTimerUp { get { return totalTime <= 0; } }
    private void Start()
    {
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
