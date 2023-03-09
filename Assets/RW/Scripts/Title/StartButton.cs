/* Program name: Introduction to Unity scripting - Sheep saving
Project file name: StartButton.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: Starts the game when you click the start button.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) 
    {
        SceneManager.LoadScene("Game");
    }
}
