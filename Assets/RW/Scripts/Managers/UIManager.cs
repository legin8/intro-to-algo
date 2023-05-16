/* Program name: intro-to-algo
Project file name: UIManager.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: Holds Methods for saving and dropping sheep.
Also the Method that show the game over screen.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; 
    public Text sheepSavedText, sheepDroppedText;
    public GameObject gameOverWindow;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
