using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    
    public void PlayWalkSound()
    {
        SFX.Play(SoundEffect.footstep);
    }
}
