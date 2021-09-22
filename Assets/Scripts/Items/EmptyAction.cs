using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyAction : MonoBehaviour, IItemUsing
{
    public void ItemUsedUp()
    {
        FindObjectOfType<InventoryControl>().RemoveSelectedItem();
    }
}
