using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public float destroyDelay = 20f; 

    void Start()
    {

        Destroy(gameObject, destroyDelay);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            SceneManager.LoadScene(1);
        }
    }
}
