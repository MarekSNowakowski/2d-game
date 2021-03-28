using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    protected string itemName;
    [SerializeField]
    protected string itemDescription;
    [SerializeField]
    protected Sprite itemSprite;
    [SerializeField]
    protected bool usable;
    [SerializeField]
    protected ItemUseSignal itemUseSignal;
    [SerializeField]
    ItemUseType itemUseType;

    public virtual void Use()
    {
        if (usable)
        {
            if (!itemUseSignal)
            {
                Debug.LogWarning("Item use signal is missing");
            }
            else
            {
                itemUseSignal.Raise();
            }
        }
    }

    public Sprite GetItemSprite()
    {
        return itemSprite;
    }

    public bool IsUsable()
    {
        return usable;
    }

    public ItemUseType GetItemUseType()
    {
        return itemUseType;
    }
}

public enum ItemUseType
{
    tool,
    singleUse
}
