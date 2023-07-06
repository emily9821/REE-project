using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : SoundManager<BGM, BackgroundMusic>
{
    public static void Play(BackgroundMusic target)
    {
        Instance.Play(Instance.soundClips, target);
    }

    protected override void Awake()
    {
        base.Awake();
    }
}