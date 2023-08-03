using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundManager<T, TEnum>: Singleton<T> where T : MonoBehaviour where TEnum : Enum
{
    public List<SoundClip<TEnum>> soundClips;
    protected AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    protected void Play(List<SoundClip<TEnum>> clips, TEnum m)
    {
        var clip = clips.Find(x => x.sound.Equals(m)).clip;
        if (clip == null)
        {
            Debug.LogError("Clip not found.");
            return;
        }
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}

[System.Serializable]
public struct SoundClip<TEnum> where TEnum : Enum
{
    public TEnum sound;
    public AudioClip clip;
}

public enum SoundEffect
{
    doorlock_open,
    doorlock_wrong,
    phone_call_take_on,
    phone_call_take_off,
    phone_call_ringing,
    car_approach,
    footstep,
    item,
    doorlock_button,
    light_switch,
    map_transfer,
    dream2_ear_ringing,
    dream5_footstep,
    dream6_crowd_noise,
    outdoor_machine,
    drinking_water,
}

public enum BackgroundMusic
{
    test1,
    test2,
    test3,
}