using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    /*非属性首字母小写；属性命名首字母大写*/
    public int id;
    public new string name;
    public ItemType itemType;
    public string description;
    public List<Property> propertyList;
    public Sprite icon;
    public GameObject prefab;
}

public enum ItemType
{
    Weapon,
    Consumable
}

[Serializable]//将Property序列化，使其在Inspector面板中显示，可作为文件存储
public class Property
{
    public PropertyType propertyType;
    public int value;
    public Property()
    {

    }
    public Property(PropertyType propertyType, int value)
    {
        this.propertyType = propertyType;
        this.value = value;
    }
}
public enum PropertyType
{
    HPValue,
    EnergyValue,
    MentalValue,
    SpeedValue,
    AttackValue
}