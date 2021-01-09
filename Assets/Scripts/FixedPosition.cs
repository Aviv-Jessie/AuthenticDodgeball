using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class use to fix the camera view when the aspect is Free aspect. 
 */

public class FixedPosition : MonoBehaviour
{
    
    private int lastScreenWidth = 0;
    private int lastScreenHeight = 0;

    private float defaultSize;

    void Start()
    {
        defaultSize = Camera.main.orthographicSize;
    }

    void Update()
    {
        //https://answers.unity.com/questions/825188/when-the-resolution-is-changed-what-method-will-be.html?_ga=2.47962151.1637133699.1609865494-782334816.1603820678
        if (lastScreenWidth != Screen.width || lastScreenHeight != Screen.height)
        {
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
            OnScreenSizeChanged(); //<--- create this function
        }
    }
    private void OnScreenSizeChanged()
    {
        float size = transform.position.x / Camera.main.aspect;
        if (size >= defaultSize)
            Camera.main.orthographicSize = size;
    }
}
