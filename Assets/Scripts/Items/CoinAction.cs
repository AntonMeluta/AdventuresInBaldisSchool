using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinAction : MonoBehaviour, IItemUsing
{
    private Transform player;
    private Transform automatPos;
    private AutomatShop automatShop;

    [SerializeField]float range = 1.5f;

    [Inject]
    private void ConstructorLike(PlayerController playerController, AutomatShop automat)
    {
        player = playerController.transform;
        automatPos = automat.transform;
        automatShop = automat;
    }

    public void ItemUsedUp()
    {
        if (Vector3.Distance(automatPos.position, player.position) < range)
        {
            automatShop.BuyChokolate();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
    }
}
