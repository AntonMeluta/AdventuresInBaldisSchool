using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlInteaction : MonoBehaviour, IInteractionPlayerAI
{

    public float delayToRestartMoving = 30;
    public float increaseSpeedBaldis = 1;

    public GameObject quizScreen;

    public void InteractionProcess()
    {
        EventsBroker.StopHuntingFoPlayer();
        quizScreen.SetActive(true);
        Invoke("RepeatPatrolMoving", delayToRestartMoving);
    }
    
    void RepeatPatrolMoving()
    {
        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }

}
