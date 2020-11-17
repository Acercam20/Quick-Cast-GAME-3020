using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    public Transform[] startingPositions;
    public GameObject[] rooms;
    private GameObject[] wallArray;
    private GameObject[] boundaryArray;

    public bool[,] isWallThere;
    private int arrayHeight = 42;
    private int arrayWidth = 42;

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
        Debug.Log(isWallThere[40,40]);

        wallArray = GameObject.FindGameObjectsWithTag("WallPrefab");
        boundaryArray = GameObject.FindGameObjectsWithTag("BoundaryBlock");

        for (int i = 0; i < wallArray.Length; i++)
        {
            isWallThere[Mathf.Abs((int)wallArray[i].transform.position.x), (int)wallArray[i].transform.position.y] = true;
        }
        for (int i = 0; i < boundaryArray.Length; i++)
        {
            Debug.Log("I: " + i);
            Debug.Log("Boundary Length: " + boundaryArray.Length);
            Debug.Log("isWallThereLength: " + isWallThere.Length / arrayHeight);
            Debug.Log("Array location: " + Mathf.Abs((int)boundaryArray[i].transform.position.x) + ", " + Mathf.Abs((int)boundaryArray[i].transform.position.y));
            isWallThere[Mathf.Abs((int)boundaryArray[i].transform.position.x), (int)boundaryArray[i].transform.position.y] = true;
            //isWallThere[20, (int)boundaryArray[i].transform.position.y] = true;
        }

        //direction = Random.Range(1, 6); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //StartCoroutine(WaitForLoad(1.0f));
    IEnumerator WaitForLoad(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
