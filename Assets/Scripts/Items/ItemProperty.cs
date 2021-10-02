using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperty : MonoBehaviour, IInventoryItem, IInteractiveWithPlayer
{    
    Vector3 startPosition;
    Quaternion startQuaternion;

    public ItemProperty_SO itemProperty_SO;
    public InventoryControl inventoryControl;

    public bool isActiveIfRestart = true;
    public bool isAccessForNpc = false;

    private void Awake()
    {
        startPosition = transform.position;
        startQuaternion = transform.rotation;
    }

    private void Start()
    {
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        transform.position = startPosition;
        transform.rotation = startQuaternion;
        if (isActiveIfRestart)
            gameObject.SetActive(true);
    }

    public Sprite GetIconItem()
    {
        return itemProperty_SO.iconItem;
    }

    public void UsingItem()
    {
        GetComponent<IItemUsing>().ItemUsedUp();
    }
    
    public void InteractionOccurred()
    {
        inventoryControl.AddItem(this, gameObject);
    }

    public bool AccessForNpc()
    {
        return isAccessForNpc;
    }
}
