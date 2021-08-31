using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    GameObject windowToiletGame;

    void Start()
    {
        
    }

    public void InteractionProcess()
    {
        Transform player = GameObject.FindObjectOfType<PlayerController>().transform;
        //NeedFix ����������� ������ � ������ 
        windowToiletGame.SetActive(true);

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }


}
