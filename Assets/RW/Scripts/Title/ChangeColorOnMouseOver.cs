/* Program name: Introduction to Unity scripting - Sheep saving
Project file name: ChangeColorOnMouseOver.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: On start set the default color of normal color.
Changes the color based on the mouse.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model;
    public Color normalColor, hoverColor;
    
    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        model.material.color = normalColor;
    }
}
