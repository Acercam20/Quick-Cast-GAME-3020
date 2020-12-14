using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
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
            col.gameObject.GetComponent<PlayerController>().audioSource.PlayOneShot(col.gameObject.GetComponent<PlayerController>().KeySFX);
            Destroy(gameObject);
        }
    }
}
