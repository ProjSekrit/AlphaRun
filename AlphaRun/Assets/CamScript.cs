using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;

public class GameScript : MonoBehaviour
{

    public ARSessionOrigin sessionOrigin;


    void Start()
    {
        Vector3 cameraOffset = sessionOrigin.camera.transform.position;
        sessionOrigin.transform.position -= cameraOffset;
    }

    
    void Update()
    {
        
    }
}
