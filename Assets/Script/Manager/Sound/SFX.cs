using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SFX : SoundManager<SFX, SoundEffect>
{
    public static void Play(SoundEffect target)
    {
        Instance.Play(Instance.soundClips, target);
    }
    
    public void PlayOneShot(string sfx)
    {
        var m = Enum.Parse(typeof(SoundEffect), sfx);
        var clip = soundClips.Find(x => x.sound.Equals(m)).clip;
        if (clip == null)
        {
            Debug.LogError("Clip not found.");
            return;
        }
        audioSource.PlayOneShot(clip);
    }

    protected override void Awake()
    {
        base.Awake();
    }
}