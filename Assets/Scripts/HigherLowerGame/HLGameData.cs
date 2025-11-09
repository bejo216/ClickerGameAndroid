using UnityEngine;

[System.Serializable]
public class CaliberData
{
    public string displayName; // npr "9 mm", ".45 ACP"
    public float sizeValue;    // vrednost za poredjenje (vece = numericki vece)
    public Sprite sprite;      // optional: slika metka
}
