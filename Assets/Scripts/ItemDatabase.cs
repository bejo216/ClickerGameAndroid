using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Scriptable Objects/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items;

    public Item getItemByID(int id)
    {
        return items.Find(item => item.itemID == id);
    }








}
