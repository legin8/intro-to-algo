/* Program name: Introduction to Unity scripting - Sheep saving
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

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
        if (timeBetweenSpawns > 0) timeBetweenSpawns -= (float)0.05;
    }


    private IEnumerator SpawnRoutine() 
        {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
        }
    }


    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }


    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }

        sheepList.Clear();
    }
}
