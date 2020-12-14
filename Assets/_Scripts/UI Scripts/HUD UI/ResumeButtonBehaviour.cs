using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnResumeButtonPressed()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().ResumeGame();
    }
}
