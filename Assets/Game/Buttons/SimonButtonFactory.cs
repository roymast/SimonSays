using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButtonFactory : MonoBehaviour
{
    [SerializeField] Transform buttonsContainer;
    [SerializeField] SimonButton buttonPrefab;    
    SimonButtonColorFactory ColorFactory;
    SimonButtonSoundFactory SoundFactory;
    private void Awake()
    {
        InitFactories();
        SoundFactory.InitAudioClips();
    }
    void InitFactories()
    {
        ColorFactory = new SimonButtonColorFactory();
        SoundFactory = new SimonButtonSoundFactory();
    }
    public SimonButton GetSimonButtonByIndex(int index)
    {
        SimonButton s = Instantiate(buttonPrefab, buttonsContainer);        
        s.SetIndex(index);
        s.SetColor(ColorFactory.GetColorByIndex(index));        
        s.SetSound(SoundFactory.GetSoundByIndex(index));
        return s;
    }
}
