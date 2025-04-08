using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    }

    public List<ItemSO> itemList;
    public ItemSO defaultWeapon;

    //IEnumerator  Start()
    //{
    //    yield return new WaitForSeconds(5f);
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        AddItem(defaultWeapon);
    //    }
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddItem(defaultWeapon);
        }
    }
    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
        Inventory_UI.Instance.AddItem(item);

        //MessageUI.Instance.Show("你获得了一个：" + item.name);
        Debug.Log("你获得了一个：" + item.name);
    }
    public void RemoveItem(ItemSO itemSO)
    {
        itemList.Remove(itemSO);
    }

}
