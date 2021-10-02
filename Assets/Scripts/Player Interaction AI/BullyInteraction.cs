using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    private NpcController npc;

    public Transform playerPos;
    public Transform toilet;
    public InventoryControl inventoryControl;

    public GameObject pantsOnHeadScreen;

    private void Start()
    {
        npc = GetComponent<NpcController>();
    }

    public void InteractionProcess()
    {
        //≈сли у игрока есть шоколадка, монета или ключи, которые хулиган может отобрать
        if (inventoryControl.TributeToTheBully())
        {
            npc.TransitionToState(npc.patrolState);
        }
        //если отобрать нечего, игрок помещаетс€ в туалет с трусами на голове
        else
        {
            EventsBroker.StopHuntingFoPlayer();
            Transform player = FindObjectOfType<PlayerController>().transform;
            playerPos.position = toilet.position;
            pantsOnHeadScreen.SetActive(true);
            npc.TransitionToState(npc.patrolState);
        }
    }


}
