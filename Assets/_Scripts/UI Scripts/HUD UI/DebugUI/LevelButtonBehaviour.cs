using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonBehaviour : MonoBehaviour
{
    public int Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelButtonPressed()
    {
        if (Level == 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else if (Level == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (Level == 2)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (Level == 3)
        {
            SceneManager.LoadScene("Level 3");
        }
        else if (Level == 4)
        {
            SceneManager.LoadScene("Level 4");
        }
        else
        {
            Debug.Log("Trying to access unknown Level");
        }
    }
}
