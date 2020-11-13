using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [Header("Objects:")]
    //Array of objects that can be spawned
    public GameObject[] objects;

    [Header("Settings:")]
    public float interval = 1;
    public float nextTime = 0;
    public int spawnLimit = 10;
    public int currentlySpawned = 0;
    public int itemSpawnRadius = 10;
    public int playerSpellRegenTime = 3;

    [Header("Setup:")]
    public GameObject minBoundsObj;
    public GameObject maxBoundsObj;
    bool bColliding = false;
    Vector3 minBoundsVec;
    Vector3 maxBoundsVec;
    Vector3 spawnLocation = new Vector3();
    BoxCollider2D hitBox;
    private GameObject player;

    private void Start()
    {
        minBoundsVec = minBoundsObj.transform.position;
        maxBoundsVec = maxBoundsObj.transform.position;
        hitBox = GetComponent<BoxCollider2D>();

        int rand = Random.Range(0, objects.Length);
        player = GameObject.FindWithTag("Player");
        //Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            PositionTest();
            GenerateAbility();
            nextTime += interval;
        }
    }

    public void PositionTest()
    {
        if (currentlySpawned <= spawnLimit)
        {
            spawnLocation = RandomPosition(minBoundsVec, maxBoundsVec);
            transform.position = spawnLocation;

            //while (hitBox.bounds.Contains(spawnLocation))
            //while (hitBox.IsTouchingLayers(0))
            while (bColliding)
            {
                bColliding = false;
                spawnLocation = RandomPosition(minBoundsVec, maxBoundsVec);
                transform.position = spawnLocation;

            }
            GameObject player = GameObject.FindWithTag("Player");
            if (Mathf.Abs(spawnLocation.x - player.transform.position.x) <= itemSpawnRadius || Mathf.Abs(spawnLocation.y - player.transform.position.y) <= itemSpawnRadius)
            {
                InstantiateObject();
            }
        }
    }

    public void InstantiateObject()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], spawnLocation, Quaternion.identity);
        currentlySpawned++;
    }

    void OnCollisionTriggerEnter2D(Collider2D other)
    {
        bColliding = true;
    }

    void OnCollisionTriggerExit2D(Collider2D other)
    {
        bColliding = false;
    }

    public Vector3 RandomPosition(Vector3 minBounds, Vector3 maxBounds)
    {
        Vector3 newPos = new Vector3();
        newPos.x = Random.Range(minBounds.x, maxBounds.x);
        newPos.y = Random.Range(minBounds.y, maxBounds.y);

        return newPos;
    }

    public void GenerateAbility()
    {
        bool hasAbility = false;
        for (int i = 0; i < 4; i++)
        {
            if (player.GetComponent<PlayerController>().inventoryScript.isFull[i])
            {
                hasAbility = true;
            }
        }
        if (!hasAbility)
        {
            int random = Random.Range(0, objects.Length);
            Instantiate(objects[random], player.transform.position, Quaternion.identity);
        }
    }
}
