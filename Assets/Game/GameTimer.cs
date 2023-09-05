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
    public bool isTimerUp { get { return totalTime <= 0; } }
    private void Start()
    {
        GameManager.OnGameOver += () => enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        int timeLeft = (int)(totalTime - Time.time);
        timeText.text = "TimeLeft: " + ((int)(totalTime - Time.time)).ToString();
        if (timeLeft <= 0)
        {
            OnTimeUp?.Invoke();
            enabled = false;
        }
    }    
}
