using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PrincipalInteraction : MonoBehaviour, IInteractionPlayerAI
{
    private int delayPenalty = 15;
    private int increaseDelayValue = 15;
    private TrackingSpeedPlayer trackingSpeedPlayer;

    private UIManager uIManager;
    private PenaltyControl penaltyControl;

    [Inject]
    private void ConstructorLike(UIManager uI, PenaltyControl penalty)
    {
        uIManager = uI;
        penaltyControl = penalty;
    }

    private void Start()
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
        
        trackingSpeedPlayer.UpdateStatusPenalty(true);
        uIManager.penaltyPlayerScreen.
            GetComponent<PenaltyPlayerScreen>().SetValueDelay(delayPenalty);
        Invoke("PenaltyPlayerFinished", delayPenalty);
        uIManager.penaltyPlayerScreen.SetActive(true);

        Transform targetPanalty = penaltyControl.PenaltyActivated();
        GetComponent<NavMeshAgent>().destination = targetPanalty.position + Vector3.forward;
    }

    private void PenaltyPlayerFinished()
    {
        penaltyControl.PenaltyExit();
        uIManager.penaltyPlayerScreen.SetActive(false);
        trackingSpeedPlayer.UpdateStatusPenalty(false);
        delayPenalty += increaseDelayValue;
        EventsBroker.RestartHuntingForPlayer();

        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }

}
