using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Audio : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioSourceClips[] Clips;

    public void AddTrec(AudioSourceClips audioClip)
    {
        AudioSourceClips[] copyForArray = new AudioSourceClips[Clips.Length + 1];
        for (int i = 0; i < Clips.Length; i++)
        {
            copyForArray[i] = Clips[i];
        }

        copyForArray[copyForArray.Length - 1] = audioClip;
        Clips = copyForArray;
    }

    public void InitializeAudio()
    {
        Clips = new AudioSourceClips[0];
        AudioSource = GetComponent<AudioSource>();
    }

    public void Play(EnumerationsOfAudioSettings name)
    { 
            if (AudioSource.isPlaying)
            {
                AudioSource.Stop();
            }

            var preset = Clips[(int)name];
            AudioSource.clip = preset.Clip;
            AudioSource.volume = preset.Volue;
            AudioSource.pitch = preset.Pitch;
            AudioSource.Play();
    }

    public void Pause(EnumerationsOfAudioSettings name)
    {
            if (AudioSource.isPlaying)
            {
                AudioSource.Pause();
            }

            var preset = Clips[(int)name];
            AudioSource.clip = preset.Clip;
            AudioSource.volume = preset.Volue;
            AudioSource.pitch = preset.Pitch;
    }

    public void Stop(EnumerationsOfAudioSettings name)
    {

            if (AudioSource.isPlaying)
            {
                AudioSource.Stop();
            }

            var preset = Clips[(int)name];
            AudioSource.clip = preset.Clip;
            AudioSource.volume = preset.Volue;
            AudioSource.pitch = preset.Pitch;
    }

}

//Написание расширения инспектора для Audio системы.

//В инспекторе отображаются все добавленные клипы с их настройками(Volume, Pitch)

//При помощи инспектора можно добавить новый аудио клип

//Аудио клип проигрывается при помощи вызова метода, в который передается один из вариантов ENUM.
