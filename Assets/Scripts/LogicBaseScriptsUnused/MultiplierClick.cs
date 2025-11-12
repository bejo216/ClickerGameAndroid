using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickMultiplier : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text multiplierText;
    public Slider MultiplierSlider;
    [Header("Multiplier Settings")]

    private float clickIncrease = 0.2f; // how much each click adds
    private float decayRateBase = 0.005f; // base decay rate
    private float decayRatePerLevel = 0.005f; // extra decay speed per multiplier level
    private float multiplierMaxValue = 10f;
    private float currentMultiplier = 0;

    void Start()
    {
        multiplierText.text = "x" + (currentMultiplier + 1f).ToString("F1");
        InvokeRepeating(nameof(DecayMultiplier), 0.05f, 0.01f);
    }

    void Update()
    {
        multiplierText.text = "x" + (currentMultiplier + 1f).ToString("F1");
        MultiplierSlider.maxValue = multiplierMaxValue;
        MultiplierSlider.value = currentMultiplier;
    }

    public void OnClick()
    {
        currentMultiplier += clickIncrease;
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
