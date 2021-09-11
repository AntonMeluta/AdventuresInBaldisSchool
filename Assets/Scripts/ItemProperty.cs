using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperty : MonoBehaviour, IInventoryItem
{
    Sprite iconItem;

    private void Awake()
    {
        iconItem = GetComponent<SpriteRenderer>().sprite;
    }

    public Sprite GetIconItem()
    {
        return iconItem;
    }

    public void UsingItem()
    {
        //NeedFix логика при использовании предмета
    }

}
