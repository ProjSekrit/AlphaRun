using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMan : MonoBehaviour
{
    public GameObject audi;
    
    void Start()
    {
        DontDestroyOnLoad(audi);
        GetComponent<AudioSource>().Play();
        if (FindObjectOfType<AudioListener>() == null)
    {
        
        gameObject.AddComponent<AudioListener>();
    }
    }

    
    void Update()
    {
       
    }
}
