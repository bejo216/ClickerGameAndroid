using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats Instance;

    //basic stats
    public double playerWood = 0;
    public double playerCoins = 0;
    public double playerLuck = 0;
    public float playerStrength = 1;

    public double playerWoodPerClick = 0.1;

    //Wood Price
    public double woodPrice = 1;

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


}
