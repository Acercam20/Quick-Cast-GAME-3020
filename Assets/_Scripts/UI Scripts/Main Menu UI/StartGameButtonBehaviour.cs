using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGameButtonPressed()
    {
        GameObject observer = GameObject.FindWithTag("GameController");
        observer.GetComponent<GameObserverBehaviour>().SetGameplayScreen();
        //observer.GetComponent<GameObserverBehaviour>().GameDifficultyScalar = 1;
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().Setup();
        SceneManager.LoadScene("Level 1");

    }
}
