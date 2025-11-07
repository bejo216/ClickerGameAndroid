using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class InventorySceneUI : MonoBehaviour
{
    

    
    public ItemDatabase itemDatabase;
    public PlayerDataItemsController playerDataItemsController;
    //Gameobjects
    public Transform HandInventory;
    public Transform TorsoInventory;
    public Transform HeadInventory;

    public Sprite lockedImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //EQUIPPED IMAGE AND TEXTS
    public Image InventoryHandImage;
    public Image InventoryTorsoImage;
    public Image InventoryHeadImage;

    public TMP_Text InventoryIdle;
    public TMP_Text InventoryClick;
    public TMP_Text InventoryPower;

    //TOOLINFOUI
    public GameObject ToolInfoUI;
    public Image ToolInfoimage;
    public TMP_Text ToolInfoNameText;
    public TMP_Text ToolInfoTypeText;
    public TMP_Text ToolInfoDescriptionText;

    public TMP_Text ToolInfoIdleText;
    public TMP_Text ToolInfoClickText;
    public TMP_Text ToolInfoPowerText;

    public TMP_Text ToolInfoBonusIdleText;
    public TMP_Text ToolInfoBonusClickText;
    public TMP_Text ToolInfoBonusPowerText;

    public TMP_Text ToolInfoImageQuantityText;
    public TMP_Text ToolInfoQuantityText;

    //SELECTED ID
    int clickedButtonItemID;

    void Start()
    {
        RefreshUI();
        DisableItemUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshUI()
    {
        //HAND QUANTITY get children
        foreach (Transform child in HandInventory)
        {


            //CHILDREN
            GameObject slot = child.gameObject;
            Button mainButton = slot.GetComponent<Button>();
            GameObject imageObject = child.Find("Image")?.gameObject;
            GameObject ItemTextObject = child.Find("ItemText")?.gameObject;
            GameObject ItemQuantityObject = child.Find("ItemQuantity")?.gameObject;

            //CHILDREN COMPONENTS
            Image imageObjectimage = imageObject.GetComponent<Image>();
            TMP_Text ItemTextObjectText = ItemTextObject.GetComponent<TMP_Text>();
            TMP_Text ItemQuantityObjectText = ItemQuantityObject.GetComponent<TMP_Text>();

            int slotID = int.Parse(slot.name);
            if (PlayerData.Instance.GetItemCount(slotID) > 0)
            {

                mainButton.interactable = true;
                imageObjectimage.sprite = itemDatabase.getItemByID(slotID).itemIcon;
                slot.GetComponent<Image>().color = new Color(0.5568628f, 0.4f, 0.282353f);
                ItemTextObjectText.text = itemDatabase.getItemByID(slotID).itemName;
                ItemQuantityObjectText.text = "x" + PlayerData.Instance.GetItemCount(slotID).ToString();

            }
            else
            {
                mainButton.interactable = false;
                slot.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                imageObjectimage.sprite = lockedImage;
                ItemTextObjectText.text = "Locked";
                ItemQuantityObjectText.text = "";
            }

        }



        foreach (Transform child in TorsoInventory)
        {



            //CHILDREN
            GameObject slot = child.gameObject;
            Button mainButton = slot.GetComponent<Button>();
            GameObject imageObject = child.Find("Image")?.gameObject;
            GameObject ItemTextObject = child.Find("ItemText")?.gameObject;
            GameObject ItemQuantityObject = child.Find("ItemQuantity")?.gameObject;

            //CHILDREN COMPONENTS
            Image imageObjectimage = imageObject.GetComponent<Image>();
            TMP_Text ItemTextObjectText = ItemTextObject.GetComponent<TMP_Text>();
            TMP_Text ItemQuantityObjectText = ItemQuantityObject.GetComponent<TMP_Text>();

            int slotID = int.Parse(slot.name);
            if (PlayerData.Instance.GetItemCount(slotID) > 0)
            {

                mainButton.interactable = true;
                imageObjectimage.sprite = itemDatabase.getItemByID(slotID).itemIcon;
                slot.GetComponent<Image>().color = new Color(0.5568628f, 0.4f, 0.282353f);
                ItemTextObjectText.text = itemDatabase.getItemByID(slotID).itemName;
                ItemQuantityObjectText.text = "x" + PlayerData.Instance.GetItemCount(slotID).ToString();

            }
            else
            {
                mainButton.interactable = false;
                slot.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                imageObjectimage.sprite = lockedImage;
                ItemTextObjectText.text = "Locked";
                ItemQuantityObjectText.text = "";
            }

        }

        foreach (Transform child in HeadInventory)
        {



            //CHILDREN
            GameObject slot = child.gameObject;
            Button mainButton = slot.GetComponent<Button>();
            GameObject imageObject = child.Find("Image")?.gameObject;
            GameObject ItemTextObject = child.Find("ItemText")?.gameObject;
            GameObject ItemQuantityObject = child.Find("ItemQuantity")?.gameObject;

            //CHILDREN COMPONENTS
            Image imageObjectimage = imageObject.GetComponent<Image>();
            TMP_Text ItemTextObjectText = ItemTextObject.GetComponent<TMP_Text>();
            TMP_Text ItemQuantityObjectText = ItemQuantityObject.GetComponent<TMP_Text>();

            int slotID = int.Parse(slot.name);
            if (PlayerData.Instance.GetItemCount(slotID) > 0)
            {

                mainButton.interactable = true;
                imageObjectimage.sprite = itemDatabase.getItemByID(slotID).itemIcon;
                slot.GetComponent<Image>().color = new Color(0.5568628f, 0.4f, 0.282353f);
                ItemTextObjectText.text = itemDatabase.getItemByID(slotID).itemName;
                ItemQuantityObjectText.text = "x" + PlayerData.Instance.GetItemCount(slotID).ToString();

            }
            else
            {
                mainButton.interactable = false;
                slot.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                imageObjectimage.sprite = lockedImage;
                ItemTextObjectText.text = "Locked";
                ItemQuantityObjectText.text = "";
            }

        }

        InventoryIdle.text = playerDataItemsController.GetEquippedIdleBonus().ToString("F1");
        InventoryClick.text = playerDataItemsController.GetEquippedClickBonus().ToString("F1");
        InventoryPower.text = playerDataItemsController.GetEquippedPowerBonus().ToString("F1");

        InventoryHandImage.sprite = itemDatabase.getItemByID(PlayerData.Instance.handID).itemIcon;
        InventoryTorsoImage.sprite = itemDatabase.getItemByID(PlayerData.Instance.torsoID).itemIcon;
        InventoryHeadImage.sprite = itemDatabase.getItemByID(PlayerData.Instance.headID).itemIcon;

        
        

    }

    public void ShowItemUI(int itemID)
    {

        clickedButtonItemID = itemID;
        ToolInfoNameText.text = itemDatabase.getItemByID(itemID).itemName;
        ToolInfoimage.sprite = itemDatabase.getItemByID(itemID).itemIcon;
        ToolInfoTypeText.text = itemDatabase.getItemByID(itemID).itemType;
        ToolInfoIdleText.text = itemDatabase.getItemByID(itemID).itemIdle.ToString("F1");
        ToolInfoClickText.text = itemDatabase.getItemByID(itemID).itemClick.ToString("F1");
        ToolInfoPowerText.text = itemDatabase.getItemByID(itemID).itemPower.ToString("F1");

        ToolInfoBonusIdleText.text = (itemDatabase.getItemByID(itemID).itemIdle * PlayerData.Instance.GetItemCount(itemID)).ToString("F1");
        ToolInfoBonusClickText.text = (itemDatabase.getItemByID(itemID).itemClick * PlayerData.Instance.GetItemCount(itemID)).ToString("F1");
        ToolInfoBonusPowerText.text = (itemDatabase.getItemByID(itemID).itemPower * PlayerData.Instance.GetItemCount(itemID)).ToString("F1");

        ToolInfoDescriptionText.text = itemDatabase.getItemByID(itemID).itemDescription;
        ToolInfoImageQuantityText.text = "x" + PlayerData.Instance.GetItemCount(itemID).ToString();
        ToolInfoQuantityText.text = "x" + PlayerData.Instance.GetItemCount(itemID).ToString();
        ToolInfoUI.SetActive(true);
    }

    public void DisableItemUI()
    {
        ToolInfoUI.SetActive(false);
    }

    

    public void EquipItemUIButton()
    {

        string itemType = itemDatabase.getItemByID(clickedButtonItemID).itemType;
        if (itemType == "hand")
        {
            PlayerData.Instance.SetHandItem(clickedButtonItemID);
        }
        else if(itemType == "torso")
        {
            PlayerData.Instance.SetTorsoItem(clickedButtonItemID);
        }
        else if (itemType == "head")
        {
            PlayerData.Instance.SetHeadItem(clickedButtonItemID);
        }
        else
        {

        }
        ToolInfoUI.SetActive(false);
        RefreshUI();
    }
}
