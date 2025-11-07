using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PrestigeSceneUI : MonoBehaviour
{

    public Slider prestigeSlider;

    public TMP_Text prestigeSliderText;
    public TMP_Text currentPrestigeLevelText;
    public TMP_Text currentPrestigeMultiplierText;
    public TMP_Text nextPrestigeMultiplierText;

    public GameObject PrestigeConfirmationUI;

    public float baseCost = 10;
    public float costMultiplier = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrestigeConfirmationUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        float playerLevel = (PlayerData.Instance.playerPrestigeMultiplier * 2);
        float currentMax = (baseCost * Mathf.Pow(costMultiplier, playerLevel));
        prestigeSliderText.text = PlayerData.Instance.playerWood.ToString("F1") + "/" + currentMax.ToString("F0");
        prestigeSlider.value = PlayerData.Instance.playerWood;
        prestigeSlider.maxValue = currentMax;
        currentPrestigeLevelText.text = playerLevel.ToString("F0");
        currentPrestigeMultiplierText.text = "x" + PlayerData.Instance.playerPrestigeMultiplier.ToString("F1");
        nextPrestigeMultiplierText.text = "x" + (0.5 + PlayerData.Instance.playerPrestigeMultiplier).ToString("F1");
        
    }

    public void OnClick()
    {
        float playerLevel = (PlayerData.Instance.playerPrestigeMultiplier * 2f);
        float currentMax = (baseCost * Mathf.Pow(costMultiplier, playerLevel));
        if (PlayerData.Instance.playerWood > currentMax)
        {
            PlayerData.Instance.playerPrestigeMultiplier += 0.5f;
            PlayerData.Instance.playerWood -= currentMax;

            PrestigeConfirmationUI.SetActive(false);
            //change scene and animation to play
        }
    }

    public void OpenConfirmationUI()
    {
        
        float currentMax = (baseCost * Mathf.Pow(costMultiplier, (PlayerData.Instance.playerPrestigeMultiplier * 2f)));
        //Debug.Log(currentMax);
        if (PlayerData.Instance.playerWood >= currentMax)
        {
            PrestigeConfirmationUI.SetActive(true);
        }
    }

    public void CloseConfirmationUI()
    {

        PrestigeConfirmationUI.SetActive(false);
    }
}
