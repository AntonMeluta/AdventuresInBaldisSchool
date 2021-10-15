using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrincipalInteraction : MonoBehaviour, IInteractionPlayerAI
{
    private int delayPenalty = 15;
    private int increaseDelayValue = 15;
    private TrackingSpeedPlayer trackingSpeedPlayer;

    public RigidbodyFirstPersonController fpsPlayer;

    //Towards player after penalty
    public Transform toWardsPlayer;

    //Send delay for Time UI and enable
    public GameObject doorLocker;

    private void Start()
    {
        trackingSpeedPlayer = GetComponent<TrackingSpeedPlayer>();
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        CancelInvoke();
        doorLocker.SetActive(false);
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
        UIManager.Instance.penaltyPlayerScreen.
            GetComponent<PenaltyPlayerScreen>().SetValueDelay(delayPenalty);
        Invoke("PenaltyPlayerFinished", delayPenalty);
        UIManager.Instance.penaltyPlayerScreen.SetActive(true);
        doorLocker.SetActive(true);

        GetComponent<NavMeshAgent>().destination = toWardsPlayer.position + Vector3.forward;
    }

    private void PenaltyPlayerFinished()
    {
        doorLocker.SetActive(false);
        UIManager.Instance.penaltyPlayerScreen.SetActive(false);
        trackingSpeedPlayer.UpdateStatusPenalty(false);
        delayPenalty += increaseDelayValue;
        EventsBroker.RestartHuntingForPlayer();

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }

}
