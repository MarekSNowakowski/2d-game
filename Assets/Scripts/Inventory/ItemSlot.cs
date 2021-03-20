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
    bool usable = false;

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
        item.Use();
    }

    private void Start()
    {
        if(item!=null)
        {
            usable = item.IsUsable();
            if(item.GetItemSprite()!=null)
            {
                itemImage.enabled = true;
                itemImage.sprite = item.GetItemSprite();
            }
        }
    }
}
