using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlBaldisInteraction : MonoBehaviour, IInteractionPlayerAI
{

    public GameObject windowWithQuestinos;

    void Start()
    {
        
    }

    public void InteractionProcess()
    {
        windowWithQuestinos.SetActive(true);
    }

    //Игрок ошибся в ответах
    public void FailureInteraction()
    {
        windowWithQuestinos.SetActive(false);

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);

        NpcController baldis = FindObjectOfType<BaldisInteraction>().GetComponent<NpcController>();
        baldis.TransitionToState(baldis.stalkingState);
        //NeedFix приращение скорости агента балдиса
    }

    //Игрок оттолкнул девочку
    public void ConflictInteraction()
    {
        windowWithQuestinos.SetActive(false);

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);

        //Игрок оттолнул девочку, её брат начинает охоту на игрока
        NpcController bully = FindObjectOfType<BullyInteraction>().GetComponent<NpcController>();
        bully.TransitionToState(bully.stalkingState);
    }


}
