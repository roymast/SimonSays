using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] GameSequence gameSequence;
    [SerializeField] TextMeshProUGUI pointsText;
    public int pointsValue { get; private set; }
    public int defaultPointsToAdd = 1;

    // Start is called before the first frame update
    void Start()
    {        
        defaultPointsToAdd = ModeManager.ModeConfigs.PointEachStep;
        gameSequence.OnSequenceFinished += AddPoints;
        SetPoints(0);        
    }        
    public void SetPoints(int points)
    {
        pointsValue = points;
        pointsText.text = "Points: "+pointsValue.ToString();        
    }
    public void AddPoints(int points)
    {
        pointsValue += points;
        SetPoints(pointsValue);
    }
    public void AddPoints()
    {
        pointsValue += defaultPointsToAdd;
        SetPoints(pointsValue);
    }
}
