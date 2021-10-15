using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    private NpcController npc;

    public Transform playerPos;
    public Transform toilet;

    private void Start()
    {
        npc = GetComponent<NpcController>();
    }

    public void InteractionProcess()
    {
        //���� � ������ ���� ���������, ������ ��� �����, ������� ������� ����� ��������
        if (UIManager.Instance.inventary.
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
            UIManager.Instance.pantsOnHeadGame.SetActive(true);
            npc.TransitionToState(npc.patrolState);
        }
    }


}
