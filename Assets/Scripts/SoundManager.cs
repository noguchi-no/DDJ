using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip bPM60;
    public AudioClip jumpSE;

    public AudioSource aud;
    
    public void BPM60()
    {
        aud.PlayOneShot(bPM60);
    } 
    public void JumpSE()
    {
        aud.PlayOneShot(jumpSE, 0.5f);
    }
}
