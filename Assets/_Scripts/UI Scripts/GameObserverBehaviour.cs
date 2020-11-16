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
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -100);
        mainCanvas.SetActive(false);
    }

    public void SetGameplayScreen()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        mainCanvas.SetActive(true);
    }
}
