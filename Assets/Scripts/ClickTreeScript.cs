using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TreeClickScript : MonoBehaviour
{
    public PlayerDataItemsController playerDataItemsController;

    // Assign via Inspector
    public Animator animator;
    public GameObject particlePrefab;           // The particle prefab to instantiate
    public Transform spawnTarget;  
    
    public Slider treeHealthSlider;
    public TMP_Text healthText;
    // Where to spawn the effect (optional)
    void Start()
    {
        treeHealthSlider.maxValue = MainTreeSingleton.Instance.treeMaxHealth;
        treeHealthSlider.value = MainTreeSingleton.Instance.treeCurrentHealth;
        healthText.text = MainTreeSingleton.Instance.treeCurrentHealth + "/" + MainTreeSingleton.Instance.treeMaxHealth;
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
        animator.Play("TreeClicked");
        SoundManager.Instance.PlayChop();
        PlayerData.Instance.playerWood += playerDataItemsController.getMainClickStat();
        MainTreeSingleton.Instance.TakeDamage(playerDataItemsController.getMainPowerStat());
        //slider == currenthealth
        treeHealthSlider.value = MainTreeSingleton.Instance.treeCurrentHealth;
        healthText.text = MainTreeSingleton.Instance.treeCurrentHealth + "/" + MainTreeSingleton.Instance.treeMaxHealth;
        if (MainTreeSingleton.Instance.treeCurrentHealth == 0)
        {
            animator.Play("TreeFall");
            SoundManager.Instance.PlayTreeFallSound();
            //GENERATE TYPEID AND SUCH IN SINGLETON
            MainTreeSingleton.Instance.GiveMaxHealth();
            //SET THE SLIDER AGAIN
            treeHealthSlider.maxValue = MainTreeSingleton.Instance.treeMaxHealth;
            treeHealthSlider.value = MainTreeSingleton.Instance.treeCurrentHealth;
            healthText.text = MainTreeSingleton.Instance.treeCurrentHealth + "/" + MainTreeSingleton.Instance.treeMaxHealth;
        }
        GameObject effect = Instantiate(particlePrefab, spawnPos, Quaternion.identity);
        Destroy(effect, 2f); // destroy after 2 seconds to clean up
    }
}
