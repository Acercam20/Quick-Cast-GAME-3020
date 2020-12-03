using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserverBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCanvas;
    public GameObject pauseCanvas;
    public float GameDifficultyScalar = 1;
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
        pauseCanvas.SetActive(false);
    }

    public void SetGameplayScreen()
    {
        pauseCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        GameDifficultyScalar = 1;
    }
}
