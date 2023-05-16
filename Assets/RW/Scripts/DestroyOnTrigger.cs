/* Program name: intro-to-algo
Project file name: DestroyOnTrigger.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: On trigger this script compares one tag to another tag, then calls the Destroy method.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter)) Destroy(gameObject);
    }
}
