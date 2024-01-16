using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private int minutes = 2;
    private float seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds <= 0)
        {
            if(minutes > 0)
            {
                minutes -= 1;
                seconds += 59;
            }
            else
            {
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex);
            }
        }
        seconds -= Time.deltaTime;
        print("Timer - " + minutes + ":" + seconds);
    }
}
