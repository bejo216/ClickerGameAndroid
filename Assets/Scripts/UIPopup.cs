using UnityEngine;
using TMPro;

public class UIPopup : MonoBehaviour
{
    public TMP_Text Popup;
    public float displayTime = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(string text)
    {
        Popup.text = text;
    }
}
