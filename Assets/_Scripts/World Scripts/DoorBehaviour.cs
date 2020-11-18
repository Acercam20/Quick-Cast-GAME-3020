using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<PlayerController>().hasKey)
            {
                //Advance Level
                col.gameObject.GetComponent<PlayerController>().hasKey = false;
                gameController.GetComponent<GameObserverBehaviour>().GameDifficultyScalar++;
                SceneManager.LoadScene("Level 1");
            }
        }
    }
}
