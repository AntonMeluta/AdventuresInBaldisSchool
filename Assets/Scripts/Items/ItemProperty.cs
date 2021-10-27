using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemProperty : MonoBehaviour, IInventoryItem, IInteractiveWithPlayer
{    
    private Vector3 startPosition;
    private Quaternion startQuaternion;
    private UIManager uIManager;

    public ItemProperty_SO itemProperty_SO;

    [SerializeField]private bool isActiveIfRestart = true;
    [SerializeField]private bool isAccessForNpc = false;

    [Inject]
    private void ConstructorLike(UIManager ui)
    {
        uIManager = ui;
    }

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
        uIManager.inventary.GetComponent<InventoryControl>().
            AddItem(this, gameObject);
    }

    public bool AccessForNpc()
    {
        return isAccessForNpc;
    }
}
