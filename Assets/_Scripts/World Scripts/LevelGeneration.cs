using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    public Transform[] startingPositions;
    public GameObject[] rooms;

    public GameObject keyPrefab;
    public GameObject doorPrefab;
    public int doorSafetyRadius;

    private GameObject[] wallArray;
    private GameObject[] boundaryArray;

    public bool[,] isWallThere;
    private int arrayHeight = 42;
    private int arrayWidth = 42;
    private bool keyIsSpawned = false;
    //private int direction;

    private void Start()
    {
        int StartingPos = 0;
        transform.position = startingPositions[StartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        for (int i = 0; i < startingPositions.Length; i++)
        {
            transform.position = startingPositions[i].position;
            Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
        }

        isWallThere = new bool[arrayWidth, arrayHeight];
        boundaryArray = GameObject.FindGameObjectsWithTag("BoundaryBlock");
        
        for (int i = 0; i < boundaryArray.Length; i++)
        {
            isWallThere[Mathf.Abs((int)boundaryArray[i].transform.position.x), (int)boundaryArray[i].transform.position.y] = true;
        }

        Debug.Log(isWallThere[0, 0]);
        //direction = Random.Range(1, 6); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!keyIsSpawned)
        {
            keyIsSpawned = true;
            wallArray = GameObject.FindGameObjectsWithTag("WallPrefab");

            for (int i = 0; i < wallArray.Length; i++)
            {
                isWallThere[Mathf.Abs((int)wallArray[i].transform.position.x), (int)wallArray[i].transform.position.y] = true;
            }
            SpawnDoor();
            SpawnKey();
        }
    }

    public Vector3 ScoutSpawnLocation()
    {
        wallArray = GameObject.FindGameObjectsWithTag("WallPrefab");
        for (int i = 0; i < wallArray.Length; i++)
        {
            isWallThere[Mathf.Abs((int)wallArray[i].transform.position.x), (int)wallArray[i].transform.position.y] = true;
        }

        int spawnX = Random.Range(0, arrayWidth);
        int spawnY = Random.Range(0, arrayHeight);

        while (isWallThere[spawnX, spawnY])
        {
            spawnX = Random.Range(0, arrayWidth);
            spawnY = Random.Range(0, arrayHeight);
        }

        return new Vector3(-spawnX, spawnY, 0);
    }

    //StartCoroutine(WaitForLoad(1.0f));
    IEnumerator WaitForLoad(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void SpawnKey()
    {
        int spawnX = Random.Range(0, arrayWidth);
        int spawnY = Random.Range(0, arrayHeight);
        while (isWallThere[spawnX, spawnY])
        {
            spawnX = Random.Range(0, arrayWidth);
            spawnY = Random.Range(0, arrayHeight);
        }
        Instantiate(keyPrefab, new Vector3(-spawnX, spawnY, 0), Quaternion.identity);
    }

    void SpawnDoor()
    {
        int doorX = -20;
        int doorY = 25;
        Instantiate(doorPrefab, new Vector3(doorX, doorY, 0), Quaternion.identity);
    }
}
