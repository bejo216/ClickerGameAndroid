using UnityEngine;

public class PlayerDataItemsController : MonoBehaviour
{

    public ItemDatabase itemDatabase;

    //get stats from every equipped item dodati BONUS ITEME * QUANITITY ZA EQUIPPED
    public float GetEquippedIdle()
    {
        int handID = PlayerData.Instance.handID;
        int torsoID = PlayerData.Instance.torsoID;
        int headID = PlayerData.Instance.headID;

        float number = 0;
        number += itemDatabase.getItemByID(handID).itemIdle;
        number += itemDatabase.getItemByID(torsoID).itemIdle;
        number += itemDatabase.getItemByID(headID).itemIdle;

        return number;
    }

    public float GetEquippedClick()
    {
        int handID = PlayerData.Instance.handID;
        int torsoID = PlayerData.Instance.torsoID;
        int headID = PlayerData.Instance.headID;

        float number = 0;
        number = itemDatabase.getItemByID(handID).itemClick;
        number += itemDatabase.getItemByID(torsoID).itemClick;
        number += itemDatabase.getItemByID(headID).itemClick;

        return number;
    }

    public float GetEquippedPower()
    {
        int handID = PlayerData.Instance.handID;
        int torsoID = PlayerData.Instance.torsoID;
        int headID = PlayerData.Instance.headID;

        float number = 0;
        number = itemDatabase.getItemByID(handID).itemPower;
        number += itemDatabase.getItemByID(torsoID).itemPower;
        number += itemDatabase.getItemByID(headID).itemPower;

        return number;
    }

    public float GetEquippedIdleBonus()
    {
        int handID = PlayerData.Instance.handID;
        int torsoID = PlayerData.Instance.torsoID;
        int headID = PlayerData.Instance.headID;

        float number = 0;
        number += itemDatabase.getItemByID(handID).itemIdle * (float)PlayerData.Instance.GetItemCount(handID);
        number += itemDatabase.getItemByID(torsoID).itemIdle * (float)PlayerData.Instance.GetItemCount(torsoID);
        number += itemDatabase.getItemByID(headID).itemIdle * (float)PlayerData.Instance.GetItemCount(headID);

        return number;
    }

    public float GetEquippedClickBonus()
    {
        int handID = PlayerData.Instance.handID;
        int torsoID = PlayerData.Instance.torsoID;
        int headID = PlayerData.Instance.headID;

        float number;
        number = itemDatabase.getItemByID(handID).itemClick * PlayerData.Instance.GetItemCount(handID);
        number += itemDatabase.getItemByID(torsoID).itemClick * PlayerData.Instance.GetItemCount(torsoID);
        number += itemDatabase.getItemByID(headID).itemClick * PlayerData.Instance.GetItemCount(headID);

        return number;
    }

    public float GetEquippedPowerBonus()
    {
        int handID = PlayerData.Instance.handID;
        int torsoID = PlayerData.Instance.torsoID;
        int headID = PlayerData.Instance.headID;

        float number;
        number = itemDatabase.getItemByID(handID).itemPower * PlayerData.Instance.GetItemCount(handID);
        number += itemDatabase.getItemByID(torsoID).itemPower * PlayerData.Instance.GetItemCount(torsoID);
        number += itemDatabase.getItemByID(headID).itemPower * PlayerData.Instance.GetItemCount(headID);

        return number;
    }

    public float getMainIdleStat()
    {
        float number;
        number = GetEquippedIdleBonus();
        number += GetEquippedIdleBonus() * (float)PlayerData.Instance.playerPrestigeMultiplier;

        return number;

    }

    public float getMainClickStat()
    {
        float number;
        number = 0.1f;
        number += GetEquippedClickBonus();
        number += GetEquippedClickBonus() * (float)PlayerData.Instance.playerPrestigeMultiplier;
        number += GetEquippedClickBonus() * (float)PlayerData.Instance.playerClickingMultiplier;
        
        return number;

    }

    public float getMainPowerStat()
    {
        float number;
        number = 1;
        number += GetEquippedPowerBonus();
        number += GetEquippedPowerBonus() * (float)PlayerData.Instance.playerPrestigeMultiplier;
        
        return number;

    }

}
