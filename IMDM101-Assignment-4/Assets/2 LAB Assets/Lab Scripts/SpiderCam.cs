using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCam : MonoBehaviour
{
    float time;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        time ++;
        if(time > 200)
        {
            cam.depth = -2;
        }
    }
}
