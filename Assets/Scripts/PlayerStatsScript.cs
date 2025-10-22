using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats Instance;

    //basic stats
    public double playerWood = 0;
    public double playerCoins = 0;

    public double playerWoodPerClick = 1;



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
