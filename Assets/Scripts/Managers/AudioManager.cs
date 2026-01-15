using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    private Stack<AudioClip> audioRequestQueue; 

    public AudioSource sfxSource;

    public override void Init()
    {
        audioRequestQueue = new Stack<AudioClip>();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioRequestQueue.Push(clip);
    }


    private void HandleAudio()
    {
        while (audioRequestQueue.Count > 0)
        {
            AudioClip clip = audioRequestQueue.Pop();
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }
}
