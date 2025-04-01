using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory_UI : MonoBehaviour
{
    private static Inventory_UI instance;
    private GameObject uiGameObject;
    private GameObject content;
    public GameObject itemPrefab;

    private bool isShow = false;

    public ItemDetail_UI itemDetailUI;

    public static Inventory_UI Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        uiGameObject = transform.Find("InventoryUI").gameObject;
        content = transform.Find("InventoryUI/IMG_bg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if (isShow)
            {
                Hide();
                isShow = false;
            }
            else
            {
                Show();
                isShow = true;
            }
        }
    }

    public void Show()
    {
        uiGameObject.SetActive(true);
    }
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }
    public void AddItem(ItemSO itemSO)
    {

        GameObject itemGo = GameObject.Instantiate(itemPrefab);
        itemGo.transform.SetParent(content.transform);
        Item_UI itemUI = itemGo.GetComponent<Item_UI>();

        itemUI.InitItem(itemSO);

    }

    public void OnItemClick(ItemSO itemSO, Item_UI itemUI)
    {
        itemDetailUI.UpdateItemDetailUI(itemSO, itemUI);
    }

    public void OnItemUse(ItemSO itemSO, Item_UI itemUI)
    {
        Destroy(itemUI.gameObject);
        InventoryManager.Instance.RemoveItem(itemSO);

        GameObject.FindGameObjectWithTag(Tag.PLAYER).GetComponent<Player>().UseItem(itemSO);
    }
}
