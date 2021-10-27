using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HammerAction : MonoBehaviour, IItemUsing
{
    private Transform player;
    public Transform evacuationButtonTransform;
    public EvacuationButton evacuationButton;

    public float range = 1.5f;

    [Inject]
    private void ConstructorLike(PlayerController playerController)
    {
        player = playerController.transform;
    }

    public void ItemUsedUp()
    {
        if (Vector3.Distance(evacuationButtonTransform.position, player.position) < range)
        {
            evacuationButton.PlayerBrokenGlass();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
            
    }

   
}
