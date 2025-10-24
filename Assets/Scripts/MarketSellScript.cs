using UnityEngine;
using TMPro;
public class MarketSellScript : MonoBehaviour
{
    public TMP_Text WoodPrice;
    public TMP_Text CoinsSum;

    void Update()
    {
        WoodPrice.text = PlayerStats.Instance.woodPrice.ToString();
        CoinsSum.text = (PlayerStats.Instance.playerWood * PlayerStats.Instance.woodPrice).ToString();
    }

    public void OnClick()
    {

        PlayerStats.Instance.playerCoins += PlayerStats.Instance.woodPrice * PlayerStats.Instance.playerWood;
        PlayerStats.Instance.playerWood = 0;
    }
}
