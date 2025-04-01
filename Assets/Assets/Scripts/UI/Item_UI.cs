using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_UI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI ntypeText;

    public ItemSO itemSO;
    public void InitItem(ItemSO itemSO)
    {
        if (itemSO == null || iconImage == null || nameText == null || ntypeText == null)
        {
            Debug.LogError("InitItem: One or more required components are null.");
            return;
        }
        string type = "";
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                type = "ÎäÆ÷";
                break;
            case ItemType.Consumable:
                type = "ÏûºÄÆ·";
                break;
            default:
                break;
        }
        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        ntypeText.text = type;
        this.itemSO = itemSO;

    }

    public void OnClick()
    {
        Inventory_UI.Instance.OnItemClick(itemSO,this);
    }
}
