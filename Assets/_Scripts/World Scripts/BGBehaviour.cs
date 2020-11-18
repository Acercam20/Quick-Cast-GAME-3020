using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public float R, G, B;
    // Start is called before the first frame update
    void Awake()
    {
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 255, 255);
        //spriteR.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 255);
    }

    void Start()
    {
        R = Random.Range(0.0f, 1.0f);
        G = Random.Range(0.0f, 1.0f);
        B = Random.Range(0.0f, 1.0f);
        //spriteR.color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        spriteR.color = new Color(R, G, B, 255);
    }
}
