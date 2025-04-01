using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 0;

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


