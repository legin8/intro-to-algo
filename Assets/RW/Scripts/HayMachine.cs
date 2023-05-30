/* Program name: intro-to-algo
Project file name: HayMachine.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: On start LoadModel and set the color of the hay machine.
On update, update the position on screen depending on the user input, also shoot if user input says to and if you can shoot at the time.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed, horizontalBoundary = 22, shootInterval;
    private float shootTimer;
    public GameObject hayBalePrefab, blueModelPrefab, yellowModelPrefab, redModelPrefab;
    public Transform haySpawnpoint, modelParent;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    // This loads the model to the screen with the color that is selected
    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject);

        if (GameSettings.hayMachineColor == HayMachineColor.Blue) {
            Instantiate(blueModelPrefab, modelParent);
            return;
        }
        if (GameSettings.hayMachineColor == HayMachineColor.Yellow) {
            Instantiate(yellowModelPrefab, modelParent);
            return;
        }
        Instantiate(redModelPrefab, modelParent);
    }

    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    // This sets the position of the hay machine
    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) transform.Translate((transform.right * -movementSpeed) * Time.deltaTime);
        if (horizontalInput > 0&& transform.position.x < horizontalBoundary) transform.Translate((transform.right * movementSpeed) * Time.deltaTime);
    }

    // This shoots the hay if the (Space) key is pressed and stops you from firing one after another
    private void UpdateShooting()
    {
    shootTimer -= Time.deltaTime; 

    if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
        {
            shootTimer = shootInterval; 
            ShootHay(); 
        }
    }

    // Makes the hay and plays the sound
    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }
}
