/* Program name: Introduction to Unity scripting - Sheep saving
Project file name: GameStateManager.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: Hides sheepSaved and sheepDropped from the editor.
Sets Instance to this Instance on Awake.
If the Esc button is pressed then it loads the title screen.
Holds Methods for updating the sheep saved and sheep dropped on the screen.
Holds Method that puts the game over screen up.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved, sheepDropped;
    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Title");
    }


    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }


    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();
    }


    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver) GameOver();
    }
}
