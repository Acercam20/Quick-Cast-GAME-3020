using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    public bool isActive;
    public int lootID;
    public List<GameObject> lootList; 
    // Start is called before the first frame update
    void Start()
    {
        isActive = (Random.value > 0.5f);

        if (isActive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        lootID = Random.Range(0, lootList.Count);
    }

    void Deactivate()
    {
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        lootID = 0;
    }
}
