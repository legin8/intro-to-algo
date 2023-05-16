/* Program name: intro-to-algo
Project file name: TweenScale.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: This starts the heart at a set size in the editor.
Once it is less than a set size is removed.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale, timeToReachTarget;
    private float startScale, percentScaled;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) 
        {
            percentScaled += Time.deltaTime / timeToReachTarget;
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
