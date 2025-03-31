using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Playscript playScript = FindObjectOfType<Playscript>();
            if (playScript != null)
            {
                playScript.scoreup();
            }

            Destroy(gameObject);
        }
    }
}


