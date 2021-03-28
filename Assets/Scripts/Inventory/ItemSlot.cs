using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Item item;
    [SerializeField]
    Image selectImage;
    [SerializeField]
    Image itemImage;
    [SerializeField]
    TMPro.TextMeshProUGUI quantityText;
    bool usable = false;
    float quantity = 1;


    public bool Select()
    {
        selectImage.enabled = true;
        return (item != null && usable);
    }

    public void UnSelect()
    {
        selectImage.enabled = false;
    }

    public void UseItem()
    {
        if(item!=null && usable)
        {
            if (item.GetItemUseType() == ItemUseType.singleUse)
            {
                quantity -= 1;
            }
            item.Use();
            if (quantity <= 0) DestroyItem();
        }
    }

    void DestroyItem()
    {
        item = null;
        usable = false;
        quantityText.enabled = false;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }

    private void Start()
    {
        if (item != null)
        {
            usable = item.IsUsable();
            if (item.GetItemSprite() != null)
            {
                itemImage.enabled = true;
                itemImage.sprite = item.GetItemSprite();
            }
            if (item.GetItemUseType() == ItemUseType.singleUse)
            {
                quantityText.enabled = true;
                quantityText.text = quantity.ToString();
            }
        }
    }
}
