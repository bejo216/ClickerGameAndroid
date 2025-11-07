using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/ItemIDs")]
public class Item : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string itemType;
    public Sprite itemIcon;
    public string itemDescription;


    public float itemIdle;  
    public float itemClick;
    public float itemPower;

}
