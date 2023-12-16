using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // Example: Adjust orthographic size based on screen width
        float targetWidth = 47.0f; // Set your desired width here
        float screenAspect = (float)Screen.width / Screen.height;
        float orthoSize = targetWidth / screenAspect;
        mainCamera.orthographicSize = orthoSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
