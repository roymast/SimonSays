using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameTimer : MonoBehaviour
{
    public Action TimeUp;
    [SerializeField] TextMeshProUGUI timeText;
    public int totalTime;    

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        int timeLeft = (int)(totalTime - Time.time);
        timeText.text = "TimeLeft: " + ((int)(totalTime - Time.time)).ToString();
        if (timeLeft <= 0)
        {
            TimeUp?.Invoke();
            enabled = false;
        }
    }
}
