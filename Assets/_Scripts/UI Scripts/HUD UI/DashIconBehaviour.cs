using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashIconBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().dashCD)
        {
            GetComponent<Image>().color = new Color32(155, 155, 125, 100);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
    }
}
