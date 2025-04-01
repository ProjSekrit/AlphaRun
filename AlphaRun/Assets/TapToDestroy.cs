using UnityEngine;

public class TapToDestroy : MonoBehaviour
{
    void Update()
    {
        // Touch input (mobile)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TryRaycast(Input.GetTouch(0).position);
        }

        // Mouse input (for testing in Editor)
        if (Input.GetMouseButtonDown(0))
        {
            TryRaycast(Input.mousePosition);
        }
    }

    void TryRaycast(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("🧊 Cube was tapped — destroying!");
                Destroy(gameObject);
            }
        }
    }
}

