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
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        CancelInvoke();
        GetComponent<TrackingSpeedPlayer>().UpdateStatusPenalty(false);
        delayPenalty = 15;
    }

    public void InteractionProcess()
    {
        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);

        EventsBroker.StopHuntingFoPlayer();

        fpsPlayer.transform.position = toWardsPlayer.position;        
        trackingSpeedPlayer.UpdateStatusPenalty(true);
        penaltyScreen.SetValueDelay(delayPenalty);
        Invoke("PenaltyPlayerFinished", delayPenalty);
        penaltyPlayerScreen.SetActive(true);
        
        GetComponent<NavMeshAgent>().destination = toWardsPlayer.position + Vector3.forward;
    }

    private void PenaltyPlayerFinished()
    {
        penaltyPlayerScreen.SetActive(false);
        trackingSpeedPlayer.UpdateStatusPenalty(false);
        delayPenalty += increaseDelayValue;
        EventsBroker.RestartHuntingForPlayer();

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }

}
