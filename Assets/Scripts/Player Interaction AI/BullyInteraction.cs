using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    private NpcController npc;
    private UIManager uIManager;

    private Transform playerPos;
    private Transform toilet;

    [Inject]
    private void ConstructorLike(PlayerController playerController, UIManager ui)
    {
        playerPos = playerController.transform;
        uIManager = ui;
    }

    private void Start()
    {
        npc = GetComponent<NpcController>();
        toilet = GameObject.Find("Toilet").transform;
    }

    public void InteractionProcess()
    {
        //���� � ������ ���� ���������, ������ ��� �����, ������� ������� ����� ��������
        if (uIManager.inventary.
                GetComponent<InventoryControl>().TributeToTheBully())
        {
            npc.TransitionToState(npc.patrolState);
        }
        //���� �������� ������, ����� ���������� � ������ � ������� �� ������
        else
        {
            EventsBroker.StopHuntingFoPlayer();
            Transform player = FindObjectOfType<PlayerController>().transform;
            playerPos.position = toilet.position;
            uIManager.pantsOnHeadGame.SetActive(true);
            npc.TransitionToState(npc.patrolState);
        }
    }


}
