using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrapAction : MonoBehaviour, IItemUsing
{
    private GameObject trapInScene;

    [Inject]
    private void ConstructorLike(TrapControl trap)
    {
        trapInScene = trap.gameObject;
    }

    public void ItemUsedUp()
    {
        trapInScene.SetActive(true);
        FindObjectOfType<InventoryControl>().RemoveSelectedItem();
    }
}
