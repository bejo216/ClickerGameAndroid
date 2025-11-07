using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{

    public static PlayerData Instance;

    //basic stats
    public float playerWood = 0;
    public float playerCoins = 0;
    public float playerLuck = 0;
    public float playerStrength = 1;

    public float playerPrestigeMultiplier = 0;
    public float playerClickingMultiplier = 0;

    public float playerWoodPerClick = 0.1f;
    public float playerWoodPerSecond = 0;
    //Wood Price
    public float woodPrice = 1;

    //INVENTORY DICT
    public Dictionary<int, int> inventory = new Dictionary<int, int>();
    
    //PLAYER EQUIPMENT
    public int handID = 0;
    public int torsoID = 0;
    public int headID = 0;
    //SETTINGS
    public float masterVolume = 0.75f;
    public float sfxVolume = 0.75f;
    public float musicVolume = 0.75f;
    
    //UPGRADE IDS
    public int upgradeID1 = 0;
    public int upgradeID2 = 0;
    public int upgradeID3 = 0;
    public int upgradeID4 = 0;
    public int upgradeID5 = 0;
    public int upgradeID6 = 0;
    public int upgradeID7 = 0;
    public int upgradeID8 = 0;
    public int upgradeID9 = 0;
    public int upgradeID10 = 0;
    public int upgradeID11 = 0;
    public int upgradeID12 = 0;
    public int upgradeID13 = 0;
    public int upgradeID14 = 0;
    public int upgradeID15 = 0;
    public int upgradeID16 = 0;

    private void Awake()
    {
        // Singleton pattern setup
        if (Instance == null)
        {

            Instance = this;
            Instance.inventory[2] = 2;
            Instance.inventory[102] = 4;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }

        //INITIALIZE FROM SQL DATABASE
    }



    
    public void AddPlayerWood(int wood)
    {
        if (wood <= 0) return;

        playerWood += wood;

    }


    public void AddPlayerWoodClick()
    {
        playerWood += playerWoodPerClick;
    }

    public void AddItem(int itemID, int amount)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID] += amount;
        }
        else
        {
            inventory[itemID] = amount;
        }
    }

    public void RemoveItem(int itemID, int amount)
    {
        if (!inventory.ContainsKey(itemID)) return;
        
        inventory[itemID] -= amount;
        if (inventory[itemID] < 0)
        {
            inventory.Remove(itemID);
        }
        
        
        
    }

    public int GetItemCount(int itemID)
    {
        return inventory.TryGetValue(itemID, out int count) ? count : 0;
        
    }

    public void SetHandItem(int itemID)
    {
        if (inventory.ContainsKey(itemID))
        {
            handID = itemID;
        }
        
    }

    public void SetTorsoItem(int itemID)
    {
        if (inventory.ContainsKey(itemID))
        {
            torsoID = itemID;
        }

    }

    public void SetHeadItem(int itemID)
    {
        if (inventory.ContainsKey(itemID))
        {
            headID = itemID;
        }

    }


    public int[] GetEquippedItemID()
    {
        int[] numbers = { handID, torsoID, headID };
        return numbers;
    }

}
