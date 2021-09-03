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
    public GameObject penaltyWindow;

    //Towards player after penalty
    public Transform toWardsPlayer;
    public GameObject doorLocker;

    void Start()
    {
        trackingSpeedPlayer = GetComponent<TrackingSpeedPlayer>();
    }

    public void InteractionProcess()
    {
        Transform player = FindObjectOfType<PlayerController>().transform;
        fpsPlayer.transform.position = toWardsPlayer.position;
        doorLocker.SetActive(true);
        penaltyWindow.SetActive(true);
        trackingSpeedPlayer.UpdateStatusPenalty();
        Invoke("PenaltyPlayerFinished", delayPenalty);

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
        GetComponent<NavMeshAgent>().destination = toWardsPlayer.position + Vector3.forward;
    }

    void PenaltyPlayerFinished()
    {
        trackingSpeedPlayer.UpdateStatusPenalty();
        delayPenalty += increaseDelayValue;
        doorLocker.SetActive(false);
        penaltyWindow.SetActive(false);
    }

}
