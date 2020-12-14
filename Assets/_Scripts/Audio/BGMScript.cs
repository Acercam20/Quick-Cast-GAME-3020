using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMScript : MonoBehaviour
{
    public AudioClip Zephyr;
    public AudioClip StreetLove;
    // Start is called before the first frame update
    bool menuBGM = true;
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && menuBGM)
        {
            GetComponent<AudioSource>().clip = Zephyr;
            GetComponent<AudioSource>().Play();
            menuBGM = false;
        }
        else if (!menuBGM && SceneManager.GetActiveScene().name != "Level 1")
        {
            GetComponent<AudioSource>().clip = StreetLove;
            GetComponent<AudioSource>().Play();
            menuBGM = true;
        }
    }
}
