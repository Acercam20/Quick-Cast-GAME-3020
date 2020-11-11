using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private GameObject objectToSpawn;

    void Start()
    {
        objectToSpawn = GameObject.FindWithTag("WallPrefab");
        GameObject instance = (GameObject)Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        //instance.transform.parent = transform;
    }

    void Update()
    {

    }

    //End of class
}
