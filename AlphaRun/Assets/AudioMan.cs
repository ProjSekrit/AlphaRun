using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMan : MonoBehaviour
{
    public GameObject audi;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(audi);
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("🎵 AudioSource playing: " + GetComponent<AudioSource>().isPlaying);
    }
}
