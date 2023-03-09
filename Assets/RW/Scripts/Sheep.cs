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
        runSpeed += (float)0.02;
    }

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
