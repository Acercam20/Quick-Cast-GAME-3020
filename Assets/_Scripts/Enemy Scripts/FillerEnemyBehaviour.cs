using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerEnemyBehaviour : MonoBehaviour
{
    public int Health = 2;
    public float Speed = 3;
    public bool willDropItem;
    public int scoreValue = 10;
    public GameObject[] dropTable;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        int dropCheck = Random.Range(0, 5);
        if (dropCheck == 5)
        {
            willDropItem = true;
        }
        else
        {
            willDropItem = false;
        }
        /*if (dropTable[0] == null)
        {
            //Set a default
        }*/
    }

    // Update is called once per frame
    // Note: Should probably call HealthCheck in a trigger function based on a change in health, so it's not wasting resources checking every frame.
    void Update()
    {
        HealthCheck();
    }
    
    void HealthCheck()
    {
        if (Health <= 0)
        {
            KillEnemy();
        }
    }

    public void ReduceHealth(int damageTaken)
    {
        Health -= damageTaken;
    }

    public void KillEnemy()
    {
        if (willDropItem)
        {
            GameObject itemDrop = dropTable[Random.Range(0, dropTable.Length)];
            Instantiate(itemDrop, gameObject.transform.position, Quaternion.identity);
        }
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerController>().AddScore(scoreValue);
        Destroy(gameObject);
    }
}
