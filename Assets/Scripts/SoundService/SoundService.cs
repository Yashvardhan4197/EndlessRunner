
using System;
using UnityEngine;

public class SoundService
{
    private AudioSource bgAudioSource;
    private AudioSource sFXAudioSource;
    private SoundType[] soundTypes;

    public SoundService(AudioSource bgAudioSource, AudioSource sFXAudioSource, SoundType[] soundTypes)
    {
        this.bgAudioSource = bgAudioSource;
        this.sFXAudioSource = sFXAudioSource;
        this.soundTypes = soundTypes;
    }

    private AudioClip GetAudioClip(Sound soundName)
    {
        SoundType item=Array.Find(soundTypes,i=>i.soundName == soundName);
        if(item==null)
        {
            return null;
        }
        return item.soundClip;
    }

    public void PlayBackGroundMusic(Sound soundName)
    {
        AudioClip clip= GetAudioClip(soundName);
        if(clip != null)
        {
            sFXAudioSource.PlayOneShot(clip);
        }
    }

    public void PlaySFX(Sound soundName)
    {
        AudioClip clip=GetAudioClip(soundName);
        if (clip!=null)
        {
            bgAudioSource.clip = clip;
            bgAudioSource.Play();
        }
    }

}
