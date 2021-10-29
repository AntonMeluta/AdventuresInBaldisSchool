using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TapeRecorderAction : MonoBehaviour, IItemUsing
{
    private Transform player;
    private Transform tapeRecorderPos;
    private TapeRecorderControl tapeRecorder;

    [SerializeField]float range = 3f;

    [Inject]
    private void ConstructorLike(PlayerController playerController, TapeRecorderControl tape)
    {
        player = playerController.transform;
        tapeRecorderPos = tape.transform;
        tapeRecorder = tape;
    }

    public void ItemUsedUp()
    {
        if (Vector3.Distance(tapeRecorderPos.position, player.position) < range)
        {
            tapeRecorder.DiscoStart();
            FindObjectOfType<InventoryControl>().RemoveSelectedItem();
        }
    }
}
