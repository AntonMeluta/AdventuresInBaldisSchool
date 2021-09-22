using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAction : MonoBehaviour, IItemUsing
{
    public Transform player;
    public Transform evacuationButtonTransform;
    public EvacuationButton evacuationButton;

    public float range = 1.5f;

    public void ItemUsedUp()
    {
        if (Vector3.Distance(evacuationButtonTransform.position, player.position) < range)
        {
            evacuationButton.PlayerBrokenGlass();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
            
    }

   
}
