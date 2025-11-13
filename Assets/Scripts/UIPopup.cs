using UnityEngine;

public class UIPopup : MonoBehaviour
{
    

     public float moveSpeed = 2f;  // how fast it moves up
    public float lifetime = 1f;    // how long it stays
    private float timer = 0f;

    void Update()
    {
        // Move the popup upwards
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Destroy after lifetime
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
