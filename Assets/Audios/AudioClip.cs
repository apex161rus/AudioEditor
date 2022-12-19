using UnityEngine;
[System.Serializable]

public class AudioSourceClips
{
    public AudioClip Clip;
    public float Volue;
    public float Pitch;

    public AudioSourceClips(AudioClip clip)
    {
        Clip = clip;
    }
}