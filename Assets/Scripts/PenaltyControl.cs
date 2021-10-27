using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PenaltyControl : MonoBehaviour
{
    private PlayerController player;

    public Transform targetTransitionPlayer;
    public GameObject doorLocked;

    [Inject]
    private void ConstructorLike(PlayerController playerController)
    {
        player = playerController;
    }

    private void Start()
    {
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        PenaltyExit();
    }

    public Transform PenaltyActivated()
    {
        player.PenaltyTransition(targetTransitionPlayer);
        doorLocked.SetActive(true);
        return targetTransitionPlayer;
    }

    public void PenaltyExit()
    {
        doorLocked.SetActive(false);
    }
}
