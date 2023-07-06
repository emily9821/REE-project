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

    protected override void Awake()
    {
        base.Awake();
    }
}