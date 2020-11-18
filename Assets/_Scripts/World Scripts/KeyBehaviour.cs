using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int decider = Random.Range(1, 3);
        if (decider == 1)
        {
            gameObject.transform.position = new Vector3(-25, 10, 0);
        }
        else if (decider == 2)
        {
            gameObject.transform.position = new Vector3(-15, 10, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(-20, 10, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().hasKey = true;
            Destroy(gameObject);
        }
    }
}
