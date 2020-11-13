using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextBehaviour : MonoBehaviour
{
    TextMeshProUGUI TextPro;
    GameObject player;
    private int playerScore = -1;
    void Start()
    {
        TextPro = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player");
        //playerScore = player.GetComponent<PlayerController>().score;

    }

    void Update()
    {
        if (playerScore != player.GetComponent<PlayerController>().score)
        {
            playerScore = player.GetComponent<PlayerController>().score;
            TextPro.text = "Score: " + playerScore;
        }
    }
}
