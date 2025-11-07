using UnityEngine;

[CreateAssetMenu(fileName = "Tree", menuName = "Scriptable Objects/TreeIDs")]
public class Tree : ScriptableObject
{
    public int treeID;
    public string treeName;
    public string treeType;
    public Sprite treeIcon;
    public string treeDescription;


    public float treeHealth;  
    //public float treeClick;
    public float treeFellGain;

}
