using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeRecorderAction : MonoBehaviour, IItemUsing
{
    public Transform player;
    public Transform tapeRecorderPos;
    public TapeRecorderControl tapeRecorder;

    public float range = 3f;

    public void ItemUsedUp()
    {
        if (Vector3.Distance(tapeRecorderPos.position, player.position) < range)
        {
            tapeRecorder.DiscoStart();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
    }
}
