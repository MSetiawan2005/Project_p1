using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject container;
    int timeScale = 0;

    private void Start()
    {
        container.SetActive(false);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = timeScale;
            timeScale = (timeScale + 1) % 2;
            
            container.SetActive(!container.active);
        }
    }
}
