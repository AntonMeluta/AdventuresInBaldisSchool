using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IceAction : MonoBehaviour, IItemUsing
{
    private GameObject iceInScene;

    [Inject]
    private void ConstructorLike(IceSceneMoving ice)
    {
        iceInScene = ice.gameObject;
    }

    public void ItemUsedUp()
    {
        iceInScene.SetActive(true);
        FindObjectOfType<InventoryControl>().RemoveSelectedItem();
    }
}
