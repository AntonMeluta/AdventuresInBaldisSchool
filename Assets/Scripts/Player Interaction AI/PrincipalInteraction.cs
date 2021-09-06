using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrincipalInteraction : MonoBehaviour, IInteractionPlayerAI
{
    int delayPenalty = 15;
    int increaseDelayValue = 15;
    TrackingSpeedPlayer trackingSpeedPlayer;

    public RigidbodyFirstPersonController fpsPlayer;

    //Towards player after penalty
    public Transform toWardsPlayer;

    //Send delay for Time UI
    public PenaltyPlayerScreen penaltyScreen;

    void Start()
    {
        trackingSpeedPlayer = GetComponent<TrackingSpeedPlayer>();
    }

    public void InteractionProcess()
    {
        Transform player = FindObjectOfType<PlayerController>().transform;
        fpsPlayer.transform.position = toWardsPlayer.position;        
        trackingSpeedPlayer.UpdateStatusPenalty();
        penaltyScreen.SetValueDelay(delayPenalty);
        Invoke("PenaltyPlayerFinished", delayPenalty);
        GameManager.Instance.UpdateGameState(GameManager.GameState.penaltyPlayer);

        /*NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);*/
        EventsBroker.StopHuntingFoPlayer();
        GetComponent<NavMeshAgent>().destination = toWardsPlayer.position + Vector3.forward;
    }

    void PenaltyPlayerFinished()
    {
        trackingSpeedPlayer.UpdateStatusPenalty();
        delayPenalty += increaseDelayValue;
    }

}
