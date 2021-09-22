using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellAction : MonoBehaviour, IItemUsing
{
    public Transform player;
    public Transform bellTransform;
    public BellControl bellInScene;

    public float range = 3f;

    public void ItemUsedUp()
    {
        if (Vector3.Distance(bellTransform.position, player.position) < range)
        {
            bellInScene.PlayerPutBattaries();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
    }
}
