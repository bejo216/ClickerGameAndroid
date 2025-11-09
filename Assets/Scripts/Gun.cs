using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/GunIDs")]
public class Gun : ScriptableObject
{
    public int gunID;
    public string gunName;
    public float gunBasePrice;
    public float gunProductionCost;
    public string gunType;
    public string gunFirerate;
    public Sprite gunIcon;
    public string gunDescription;


    

}
