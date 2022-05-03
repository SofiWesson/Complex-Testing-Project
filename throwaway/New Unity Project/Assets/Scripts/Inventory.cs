using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot
{
    public GameObject obj;
    public bool isEmpty = true;
}

public class Inventory : MonoBehaviour
{
    public int numSlots;
    public GameObject prefab;

    Items items;

    List<Slot> slots = new List<Slot>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            GameObject slotObj = Instantiate(prefab);
            slot.obj = slotObj;
            slot.obj.transform.SetParent(this.transform);
            slots.Add(slot);
        }

        items = GetComponent<Items>();
    }

    void Add(int itemID, int amountToAdd)
    {
        HeldItem slot = null;

        for (int i = this.transform.childCount; i >= 1 ; i--)
        {
            slot = this.transform.GetChild(i - 1).GetComponent<HeldItem>();
            if (slot.heldItemID == itemID && items.items[itemID].countInInventory != items.items[itemID].stackMax)
                break;
            if (i == 1)
                slot = null;
        }

        if (slot == null)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                slot = this.transform.GetChild(i).GetComponent<HeldItem>();
                if (slot.heldItemID == 0)
                    break;

                if (i == this.transform.childCount)
                    slot = null;
            }
        }

        int over = 0;

        if (slot.heldItemID != 0)
        {
            Transform itemObj = slot.GetComponent<Transform>().GetChild(0);

            itemObj.GetComponent<Image>().sprite = items.items[itemID].sprite;
            items.items[itemID].countInInventory += amountToAdd;
            if (items.items[itemID].countInInventory > items.items[itemID].stackMax)
            {
                over = items.items[itemID].countInInventory - items.items[itemID].stackMax;
                items.items[itemID].countInInventory = items.items[itemID].stackMax;
            }
        }
        else
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].isEmpty)
                {
                    Transform slotObj = slot.GetComponent<Transform>();
                    Image itemImage = slotObj.GetChild(0).GetComponent<Image>();

                    itemImage.sprite = items.items[itemID].sprite;
                    itemImage.color = new Vector4(itemImage.color.r, itemImage.color.g, itemImage.color.b, 1);
                    items.items[itemID].countInInventory += amountToAdd;
                    slot.heldItemID = itemID;
                    slots[i].isEmpty = false;
                    break;
                }
            }
        }

        if (over > 0)
            Add(itemID, over);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
