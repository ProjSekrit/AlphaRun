using UnityEngine;

public class TapToDestroy : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TryRaycast(Input.GetTouch(0).position);
        }


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
                Destroy(gameObject);
            }
        }
    }
}

