using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStartPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f; //stops time
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTime()
    {
        Time.timeScale = 1f; //starts time
    }
}
