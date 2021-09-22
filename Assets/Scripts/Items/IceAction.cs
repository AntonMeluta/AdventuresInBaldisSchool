using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAction : MonoBehaviour, IItemUsing
{
    public GameObject iceInScene;

    public void ItemUsedUp()
    {
        iceInScene.SetActive(true);
        FindObjectOfType<InventoryControl>().RemoveSelectedItem();
    }
}
