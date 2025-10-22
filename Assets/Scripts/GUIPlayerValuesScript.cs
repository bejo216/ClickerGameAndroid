using UnityEngine;
using TMPro;
public class GUIPlayerValuesScript : MonoBehaviour
{

    public TMP_Text WoodText;
    public TMP_Text CoinsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WoodText.text = PlayerStats.Instance.playerWood.ToString();
        CoinsText.text = PlayerStats.Instance.playerCoins.ToString();
    }


    //formatting

}
