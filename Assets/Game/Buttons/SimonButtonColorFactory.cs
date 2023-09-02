using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButtonColorFactory
{
    public Color[] colors;
    public SimonButtonColorFactory()
    {
        colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow, Color.cyan, Color.gray };
    }
    public Color GetColorByIndex(int index)
    {
        if (index < colors.Length)
            return colors[index];
        else
            return Color.black;
    }
}
