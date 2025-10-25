using UnityEngine;

public class MainTreeSingleton : MonoBehaviour
{

    public static MainTreeSingleton Instance;



    

    public float treeCurrentHealth;
    public int treeTypeID;
    public float treeMaxHealth;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            treeCurrentHealth = treeMaxHealth;
            DontDestroyOnLoad(gameObject); // Keeps it between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }

        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public void TakeDamage(float damage)
    {
        if (treeCurrentHealth < damage)
        {
            treeCurrentHealth = 0;
        }
        else
        {
            treeCurrentHealth -= damage;
        }       
    }   

    public void GiveMaxHealth()
    {
        treeCurrentHealth = treeMaxHealth;
        
    }

    public void GenerateTreeTypeID()
    {
        treeTypeID=1;//NEEDS LOGIC

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
