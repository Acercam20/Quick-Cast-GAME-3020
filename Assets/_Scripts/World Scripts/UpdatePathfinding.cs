using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePathfinding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("UpdatePathfindingGrid", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePathfindingGrid()
    {
        AstarPath.active.Scan();
    }
}
