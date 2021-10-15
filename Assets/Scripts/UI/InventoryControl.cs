using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    private int indexSelectedSlot;
    private Dictionary<int, IInventoryItem> dictionaryItems;

    public Button useButton;
    public Button[] buttonsSlot;
    public Image[] imagesInnerSlot;
    public Image[] imagesOuterSlot;


    private void Start()
    {
        EventsBroker.EventRestartGame += RestartGame;

        indexSelectedSlot = 0;
        dictionaryItems = new Dictionary<int, IInventoryItem>();
        useButton.onClick.AddListener(UseButtonAction);

        for (int i = 0; i < buttonsSlot.Length; i++)
        {
            int interimValue = i;
            buttonsSlot[i].onClick.AddListener(() => SlotSelected(interimValue));
            dictionaryItems.Add(i, null);
        }
    }
    
    private void RestartGame()
    {
        indexSelectedSlot = 0;
        dictionaryItems = new Dictionary<int, IInventoryItem>();
        for (int i = 0; i < buttonsSlot.Length; i++)
        {
            dictionaryItems.Add(i, null);
            imagesInnerSlot[i].sprite = null; 
            imagesOuterSlot[i].color = Color.white;
        }
        imagesOuterSlot[0].color = Color.red;
    }

    private void UseButtonAction()
    {
        if (dictionaryItems[indexSelectedSlot] != null)
        {
            dictionaryItems[indexSelectedSlot].UsingItem();
            return;
        }
    }

    public void RemoveSelectedItem()
    {
        dictionaryItems[indexSelectedSlot] = null;
        imagesInnerSlot[indexSelectedSlot].sprite = null;
    }

    public void AddItem(IInventoryItem pickedItem, GameObject objectInScene)
    {
        for (int i = 0; i < dictionaryItems.Count; i++)
        {
            if (dictionaryItems[i] == null)
            {
                dictionaryItems[i] = pickedItem;
                imagesInnerSlot[i].sprite = dictionaryItems[i].GetIconItem();
                objectInScene.SetActive(false);
                break;
            }
        }
    }

    private void SlotSelected(int indexSlot)
    {
        indexSelectedSlot = indexSlot;
        for (int i = 0; i < imagesOuterSlot.Length; i++)
        {
            if (i == indexSelectedSlot)
            {
                imagesOuterSlot[i].color = Color.red;
                continue;
            }
            imagesOuterSlot[i].color = Color.white;
        }
    }

    public bool TributeToTheBully()
    {
        for (int i = 0; i < dictionaryItems.Count; i++)
        {
            if (dictionaryItems[i] != null && dictionaryItems[i].AccessForNpc())
            {
                dictionaryItems[i] = null;
                imagesInnerSlot[i].sprite = null;
                return true;
            }                
        }

        return false;
    }


}
