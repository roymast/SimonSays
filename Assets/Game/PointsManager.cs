using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    public int pointsValue { get; private set; }
    public int defaultPointsToAdd = 1;

    // Start is called before the first frame update
    void Start()
    {
        SetPoints(-1);
        defaultPointsToAdd = ModeManager.ModeConfigs.PointEachStep;        
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
