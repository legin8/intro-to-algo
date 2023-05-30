/* Program name: intro-to-algo
Project file name: Sheep.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: This is used for each sheep that runs across the screen.
On start it sets the current collider and rigidbody.
On update it moves each sheep and increases the speed each iteration.
Holds methods that are called when the sheep is hit or runs off the side and knows if the sheep should be spawning.
All other methods beside of Start and Update are called by other files.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed, gotHayDestroyDelay, dropDestroyDelay, heartOffset;
    private bool hitByHay, dropped;

    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;
    public GameObject heartPrefab;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.forward * runSpeed) * Time.deltaTime);
        // This makes each sheep move faster over time (Advanced)
        runSpeed += (float)0.02;
    }

    // This controls what happens when a sheep and hay connect
    private void HitByHay()
    {
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        SoundManager.Instance.PlaySheepHitClip();
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; 
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        GameStateManager.Instance.SavedSheep();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject); 
            HitByHay(); 
        }
        if (other.CompareTag("DropSheep") && !dropped) Drop();
    }

    // This removes the sheep once it has been hit by hay
    private void Drop()
    {
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
        SoundManager.Instance.PlaySheepDroppedClip();
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
