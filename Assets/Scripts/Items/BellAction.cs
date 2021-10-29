using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BellAction : MonoBehaviour, IItemUsing
{
    private Transform player;
    private Transform bellTransform;
    private BellControl bellInScene;

    [SerializeField]float range = 3f;

    [Inject]
    private void ConstructorLike(PlayerController playerController, BellControl bell)
    {
        player = playerController.transform;
        bellTransform = bell.transform;
        bellInScene = bell;
    }

    public void ItemUsedUp()
    {
        if (Vector3.Distance(bellTransform.position, player.position) < range)
        {
            bellInScene.PlayerPutBattaries();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
    }
}
