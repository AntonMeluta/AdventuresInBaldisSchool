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

    //Send delay for Time UI and enable
    public PenaltyPlayerScreen penaltyScreen;
    public GameObject penaltyPlayerScreen;

    void Start()
    {
        trackingSpeedPlayer = GetComponent<TrackingSpeedPlayer>();
    }

    public void InteractionProcess()
    {
        EventsBroker.StopHuntingFoPlayer();

        Transform player = FindObjectOfType<PlayerController>().transform;
        fpsPlayer.transform.position = toWardsPlayer.position;        
        trackingSpeedPlayer.UpdateStatusPenalty();
        penaltyScreen.SetValueDelay(delayPenalty);
        Invoke("PenaltyPlayerFinished", delayPenalty);
        penaltyPlayerScreen.SetActive(true);

        /*NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);*/
        GetComponent<NavMeshAgent>().destination = toWardsPlayer.position + Vector3.forward;
    }

    void PenaltyPlayerFinished()
    {
        penaltyPlayerScreen.SetActive(false);
        trackingSpeedPlayer.UpdateStatusPenalty();
        delayPenalty += increaseDelayValue;
    }

}
