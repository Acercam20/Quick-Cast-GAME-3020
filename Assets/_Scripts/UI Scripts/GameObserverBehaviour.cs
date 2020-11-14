using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserverBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SetUIScreen();
        DontDestroyOnLoad(mainCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUIScreen()
    {
        player.SetActive(false);
        mainCanvas.SetActive(false);
    }

    public void SetGameplayScreen()
    {
        player.SetActive(true);
        mainCanvas.SetActive(true);
    }
}
