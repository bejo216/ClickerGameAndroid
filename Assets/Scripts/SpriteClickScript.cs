using UnityEngine;

public class SpriteClickScript : MonoBehaviour
{
    public GameObject particlePrefab; // Assign your particle prefab in Inspector

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Handle touch (for Android) or mouse click (for testing in editor)
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Check if this sprite was touched
            Collider2D hit = Physics2D.OverlapPoint(touchPos);
            if (hit != null && hit.transform == transform)
            {
                Debug.Log("CLICKED");
                SpawnParticle(touchPos);
            }
        }
    }

    void SpawnParticle(Vector2 touchPos)
    {
        if (particlePrefab != null)
        {
            // Instantiate at the touch position
            GameObject particle = Instantiate(particlePrefab, touchPos, Quaternion.identity);
            Debug.Log("INSTANTIATED");
            // (Optional) Modify the particle if needed
            // e.g. change size, color, etc.

            // (Optional) Destroy after a short time
            Destroy(particle, 2f);
        }
    }
}

