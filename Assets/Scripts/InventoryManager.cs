using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    List<ItemSlot> itemSlots;
    Item selectedItem;
    int selectedSlot;
    bool itemUsable;

    private void Start()
    {
        SelectSlot(0);
        itemUsable = true; //To be fixed - first select always returns false
    }

    private void Update()
    {
        if (Input.GetButtonDown("0"))
        {
            SelectSlot(9);
        }
        else if (Input.GetButtonDown("1"))
        {
            SelectSlot(0);
        }
        else if (Input.GetButtonDown("2"))
        {
            SelectSlot(1);
        }
        else if (Input.GetButtonDown("3"))
        {
            SelectSlot(2);
        }
        else if (Input.GetButtonDown("4"))
        {
            SelectSlot(3);
        }
        else if (Input.GetButtonDown("5"))
        {
            SelectSlot(4);
        }
        else if (Input.GetButtonDown("6"))
        {
            SelectSlot(5);
        }
        else if (Input.GetButtonDown("7"))
        {
            SelectSlot(6);
        }
        else if (Input.GetButtonDown("8"))
        {
            SelectSlot(7);
        }
        else if (Input.GetButtonDown("9"))
        {
            SelectSlot(8);
        }
        if (Mathf.Abs(Input.mouseScrollDelta.y) > 0.1)
        {

        }
        if (Input.GetButtonDown("interact"))
        {
            if(itemUsable)
            {
                itemSlots[selectedSlot].UseItem();
            }
        }
    }

    private void SelectSlot(int index)
    {
        itemSlots[selectedSlot].UnSelect();
        selectedSlot = index;
        itemUsable = itemSlots[index].Select();
    }
}
