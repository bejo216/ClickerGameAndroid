using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
public class MineClick : MonoBehaviour
{
    public PlayerDataItemsController playerDataItemsController;

    // Assign via Inspector
    public Animator animator;
    public GameObject particlePrefab;           // The particle prefab to instantiate
    public Transform spawnTarget;  
    
    public Slider treeHealthSlider;
    public TMP_Text healthText;



    //Multiplier
    
    public Slider MultiplierSlider;
    public TMP_Text multiplierText;

    private float clickIncrease = 0.2f; // how much each click adds
    private float decayRateBase = 0.005f; // base decay rate
    private float decayRatePerLevel = 0.005f; // extra decay speed per multiplier level
    private float multiplierMaxValue = 10f;
    private float currentMultiplier = 0;
    
    //POPUP BRATE
    public GameObject popupPrefab;
    public Transform canvasTransform;
    // Where to spawn the effect (optional)
    void Start()
    {
        multiplierText.text = "x" + (currentMultiplier + 1f).ToString("F1");
        InvokeRepeating(nameof(DecayMultiplier), 0.05f, 0.01f);

        treeHealthSlider.maxValue = MainTreeSingleton.Instance.treeMaxHealth;
        treeHealthSlider.value = MainTreeSingleton.Instance.treeCurrentHealth;
        healthText.text = MainTreeSingleton.Instance.treeCurrentHealth + "/" + MainTreeSingleton.Instance.treeMaxHealth;
    }

    void Update()
    {
        multiplierText.text = "x" + (currentMultiplier + 1f).ToString("F1");
        MultiplierSlider.maxValue = multiplierMaxValue;
        MultiplierSlider.value = currentMultiplier;
    }

    public void SpawnParticle(BaseEventData data)
    {

        PointerEventData pointerData = data as PointerEventData;

            Vector2 clickPosition = pointerData.position; // Screen position
            Debug.Log("Button clicked at screen position: " + clickPosition);
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasTransform as RectTransform,
                clickPosition,           // your screen position
                pointerData.pressEventCamera,
                out localPoint
            );            


        currentMultiplier += clickIncrease;


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
        float value = playerDataItemsController.getMainClickStat() + (playerDataItemsController.getMainClickStat() * currentMultiplier);
        float rounded = Mathf.Floor(value * 10f) / 10f;
        PlayerData.Instance.playerWood += rounded;

        GameObject popup = Instantiate(popupPrefab, clickPosition, Quaternion.identity, canvasTransform);
        TMP_Text textComponent = popupPrefab.GetComponentInChildren<TMP_Text>();
        
        popup.transform.localPosition = localPoint;

        if (textComponent != null)
        {
            textComponent.text = "+" + rounded.ToString("F1");
        }
           

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
        //GameObject effect = Instantiate(particlePrefab, spawnPos, Quaternion.identity);
        //Destroy(effect, 2f); // destroy after 2 seconds to clean up



    }

    void DecayMultiplier()
    {
            float decayRate = decayRateBase + (currentMultiplier * decayRatePerLevel);
            currentMultiplier -= decayRate;

            if (currentMultiplier < 0)
            {
                currentMultiplier = 0f;
            }
                
        
    }
}
