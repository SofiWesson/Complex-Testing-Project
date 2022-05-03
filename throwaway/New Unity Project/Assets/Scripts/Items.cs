using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int stackMax;
    public bool isStackable;
    public bool isPlantable;
    public bool isConsumable;
    public Sprite sprite;
    public int countInInventory;
}

public class Items : MonoBehaviour
{
    public List<Item> items;
}
