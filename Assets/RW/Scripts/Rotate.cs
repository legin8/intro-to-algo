/* Program name: intro-to-algo
Project file name: Rotate.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: Makes what ever this is attached to move by the value set in the unity editor, in this case it makes the windmills turn.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;

    // Every time this is called, it changes the rotation to make it look like the hay is rolling
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
