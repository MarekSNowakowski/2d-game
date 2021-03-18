using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    string itemName;
    [SerializeField]
    Sprite itemImage;
}
