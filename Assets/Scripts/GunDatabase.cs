using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunDatabase", menuName = "Scriptable Objects/GunDatabase")]
public class GunDatabase : ScriptableObject
{
    public List<Gun> guns;

    public Gun getGunByID(int id)
    {
        return guns.Find(gun => gun.gunID == id);
    }








}
