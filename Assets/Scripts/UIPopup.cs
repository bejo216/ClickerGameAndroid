using UnityEngine;

public class UIPopup : MonoBehaviour
{
    

    public float moveSpeed = 50f; // units per second
    public float lifetime = 1f;

    private RectTransform rectTransform;
    private float timer;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Move upward in local UI space
        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

        // Lifetime timer
        timer += Time.deltaTime;
        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
