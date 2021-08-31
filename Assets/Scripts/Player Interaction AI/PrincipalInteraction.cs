using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalInteraction : MonoBehaviour, IInteractionPlayerAI
{
    public GameObject penaltyWindow;

    void Start()
    {
        
    }

    public void InteractionProcess()
    {
        Transform player = FindObjectOfType<PlayerController>().transform;
        //NeedFix Перемещение игрока в кабинет и блоkирование двери
        penaltyWindow.SetActive(true);

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }


}
