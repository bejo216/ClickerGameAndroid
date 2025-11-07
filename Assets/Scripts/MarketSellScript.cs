using UnityEngine;
using TMPro;

public class MarketSellScript : MonoBehaviour
{
    public TMP_Text WoodPrice;
    public TMP_Text CoinsSum;

    void Update()
    {
        WoodPrice.text = "$" + PlayerData.Instance.woodPrice.ToString("F1");
        CoinsSum.text =  (PlayerData.Instance.playerWood * PlayerData.Instance.woodPrice).ToString("F1");
    }

    public void OnClick()
    {
        if (PlayerData.Instance.playerWood > 0)
        {

            PlayerData.Instance.playerCoins += PlayerData.Instance.woodPrice * PlayerData.Instance.playerWood;
            PlayerData.Instance.playerWood = 0;
            SoundManager.Instance.PlayBuySound(); //sell price mora
        }
        else
        {
            SoundManager.Instance.PlayDeclineSound();
        }

           
    }
}
