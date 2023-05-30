/* Program name: intro-to-algo
Project file name: SheepSpawner.cs
Author: Nigel Maynard
Date: 10/3/23
Language: C#
Platform: Unity/ VS Code
Purpose: Assessment
Description: On start it starts the sheep spawning.
Holds the methods to destroy a single sheep and the method to destroy all sheep on game over.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true; 
    public float timeBetweenSpawns;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    private List<GameObject> sheepList = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // This spawns the sheep by creating it and adding it
    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
        // This decreases the time between spawns of each sheep (Advanced)
        if (timeBetweenSpawns > 0) timeBetweenSpawns -= (float)0.1;
    }


    // This calls spawn and then waits
    private IEnumerator SpawnRoutine() 
        {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
        }
    }


    // Removes a single sheep from the list
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }


    // Removes all sheep
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }

        sheepList.Clear();
    }
}
