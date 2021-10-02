
using UnityEngine;

public interface IInventoryItem
{
    void UsingItem();
    Sprite GetIconItem();
    bool AccessForNpc();
}
