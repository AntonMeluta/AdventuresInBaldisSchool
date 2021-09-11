using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    int indexSelectedSlot;
    Dictionary<int, IInventoryItem> dictionaryItems;

    public Button useButton;
    public Button[] buttonsSlot;
    public Image[] imagesButtonSlot;

    private void Start()
    {
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

    private void UseButtonAction()
    {
        if (dictionaryItems[indexSelectedSlot] != null)
        {
            dictionaryItems[indexSelectedSlot].UsingItem();
            print("UseButtonAction опедлерш еярэ");
            dictionaryItems[indexSelectedSlot] = null;
            imagesButtonSlot[indexSelectedSlot].sprite = null;
            return;
        }
        print("UseButtonAction опедлернб мер");
    }

    public void AddItem(IInventoryItem pickedItem, GameObject objectInScene)
    {
        for (int i = 0; i < dictionaryItems.Count; i++)
        {
            if (dictionaryItems[i] == null)
            {
                dictionaryItems[i] = pickedItem;
                imagesButtonSlot[i].sprite = dictionaryItems[i].GetIconItem();
                objectInScene.SetActive(false);
                break;
            }
        }
    }

    private void SlotSelected(int indexSlot)
    {
        indexSelectedSlot = indexSlot;
    }


}
