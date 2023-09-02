using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButtonSoundFactory
{
    AudioClip[] audioClips;
    public void InitAudioClips()
    {
        audioClips = Resources.LoadAll<AudioClip>("SimonButtonsAudio");
    }
    public AudioClip GetSoundByIndex(int index)
    {
        if (index < audioClips.Length)
            return audioClips[index];
        return null;
    }
}
