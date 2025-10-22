using UnityEngine;
using UnityEngine.UI;

public class TreeClickScript : MonoBehaviour
{
    // Assign via Inspector
    public GameObject particlePrefab;           // The particle prefab to instantiate
    public Transform spawnTarget;               // Where to spawn the effect (optional)
    void Start()
    {

    }

    public void SpawnParticle()
    {
        Vector3 spawnPos;

        if (spawnTarget != null)
        {
            spawnPos = spawnTarget.position;
        }
        else
        {
            // Default to center of screen in world space
            spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10));
        }
        PlayerStats.Instance.AddPlayerWoodClick();
        GameObject effect = Instantiate(particlePrefab, spawnPos, Quaternion.identity);
        Destroy(effect, 2f); // destroy after 2 seconds to clean up
    }
}
