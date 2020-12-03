using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [Header("Enemies:")]
    //Array of enemy types that can be spawned.
    public GameObject[] enemyList;

    [Header("Settings:")]
    public float interval = 1;
    public float nextTime = 0;
    public int spawnLimit = 10;
    public int currentlySpawned = 0;
    public int playerSafetyRadius = 5;

    GameObject gameController;
    Vector3 spawnLocation = new Vector3();
    private GameObject levelGenerator;

    private void Start()
    {
        levelGenerator = GameObject.FindWithTag("LevelGenerator");
        gameController = GameObject.FindWithTag("GameController");
        spawnLimit = 10 * (int)gameController.GetComponent<GameObserverBehaviour>().GameDifficultyScalar;
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            PositionTest();

            nextTime += interval;
        }
    }

    public void PositionTest()
    {
        if(currentlySpawned <= spawnLimit)
        {
            spawnLocation = levelGenerator.GetComponent<LevelGeneration>().ScoutSpawnLocation();
            GameObject player = GameObject.FindWithTag("Player");

            while (!(Mathf.Abs(spawnLocation.x - player.transform.position.x) >= playerSafetyRadius) || !(Mathf.Abs(spawnLocation.y - player.transform.position.y) >= playerSafetyRadius))
            {
                spawnLocation = levelGenerator.GetComponent<LevelGeneration>().ScoutSpawnLocation();
            }
            spawnLocation = levelGenerator.GetComponent<LevelGeneration>().ScoutSpawnLocation();
            InstantiatingEnemy();
        }
    }

    public void InstantiatingEnemy()
    {
        int rand = Random.Range(0, enemyList.Length);
        Instantiate(enemyList[rand], spawnLocation, Quaternion.identity);
        currentlySpawned++;
    }
}