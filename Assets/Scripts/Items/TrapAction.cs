using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAction : MonoBehaviour, IItemUsing
{
    public GameObject trapInScene;
    
    public void ItemUsedUp()
    {
        trapInScene.SetActive(true);
        FindObjectOfType<InventoryControl>().RemoveSelectedItem();
    }
}
