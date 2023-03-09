/* Program name: Introduction to Unity scripting - Sheep saving
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

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}
