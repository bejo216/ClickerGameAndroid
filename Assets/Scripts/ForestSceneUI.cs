using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ForestSceneUI : MonoBehaviour
{
    public PlayerDataItemsController playerDataItemsController;

    public TMP_Text PlayerIdleText;
    public TMP_Text PlayerClickText;
    public TMP_Text PlayerPowerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIdleText.text = playerDataItemsController.getMainIdleStat().ToString("F1");
        PlayerClickText.text = playerDataItemsController.getMainClickStat().ToString("F1");
        PlayerPowerText.text = playerDataItemsController.getMainPowerStat().ToString("F1");
    }
}
