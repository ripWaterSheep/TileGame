﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    const int volRadius = 20;
    const int panRadius = 16;
    const float volMultiplier = 1f;

    public AudioSource audioSource;
    public Transform player;

    public AudioClip doorOpened;
    public AudioClip doorClosed;
    public AudioClip botHit;


    public void PlaySound(AudioClip sound, Vector3 soundPos)
    {
        if (sound != null)
        {
            // Make volume louder the closer the sound is to player.
            float vol = 1 - (Vector2.Distance(soundPos, player.position) / volRadius);
            // Make the sound come from the direction on the x axis the position is.
            float pan = (soundPos.x - player.position.x) / panRadius;
            audioSource.panStereo = pan;

            if (vol > 0)
            {
                audioSource.PlayOneShot(sound, vol * volMultiplier);
            }
        }
    }
}