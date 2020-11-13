using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    GameObject player;
    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rt = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(player.GetComponent<PlayerController>().health * 2, rt.sizeDelta.y);
    }
}
