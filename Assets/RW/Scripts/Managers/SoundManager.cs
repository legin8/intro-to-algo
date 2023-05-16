/* Program name: intro-to-algo
Project file name: SoundManager.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: Plays Sounds when Methods are called for:
Shoot hay.
Hit Sheep.
Sheep fall.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 
    public AudioClip shootClip, sheepHitClip, sheepDroppedClip;
    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }


    // Plays music when game starts
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }


    // Sound for when you shoot
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }


    // Sound for when the sheep gets hit with hay
    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }


    // Sound for when the sheep drops off the end
    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}
