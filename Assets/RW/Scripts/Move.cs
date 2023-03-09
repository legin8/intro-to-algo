/* Program name: Introduction to Unity scripting - Sheep saving
Project file name: Move.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: Makes what ever this is attached to move by the value set in the unity editor, on the press of the space key.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed;
    public Space space;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
