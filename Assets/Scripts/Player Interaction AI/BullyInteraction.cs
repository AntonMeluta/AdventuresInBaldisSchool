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
        //���� � ������ ���� ���������, ������ ��� �����, ������� ������� ����� ��������
        if (inventoryControl.TributeToTheBully())
        {
            npc.TransitionToState(npc.patrolState);
        }
        //���� �������� ������, ����� ���������� � ������ � ������� �� ������
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
