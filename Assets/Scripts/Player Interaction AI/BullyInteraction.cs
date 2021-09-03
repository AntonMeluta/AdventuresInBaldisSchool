using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    public GameObject windowToiletGame;
    public Transform playerPos;
    public Transform toilet;

   
    public void InteractionProcess()
    {
        Transform player = GameObject.FindObjectOfType<PlayerController>().transform;
        //NeedFix ����������� ������ � ������ � ����������� ������� � ������� �� ������ 
        playerPos.position = toilet.position;
        windowToiletGame.SetActive(true);

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }


}
