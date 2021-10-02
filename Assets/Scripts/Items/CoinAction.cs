using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAction : MonoBehaviour, IItemUsing
{
    public Transform player;
    public Transform automatPos;
    public GameObject energieBar;

    public float range = 1.5f;

    public void ItemUsedUp()
    {
        if (Vector3.Distance(automatPos.position, player.position) < range)
        {
            energieBar.SetActive(true);
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
    }
}
