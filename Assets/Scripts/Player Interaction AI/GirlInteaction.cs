using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlInteaction : MonoBehaviour, IInteractionPlayerAI
{
    private float delayToReturnPatol = 10;

    [SerializeField]float increaseSpeedBaldis = 1;
    [SerializeField]bool isInGirlQuiz = false;
    
    private void OnEnable()
    {
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= RestartGame;
    }

    private void RestartGame()
    {
        CancelInvoke();
        isInGirlQuiz = false;
    }

    public bool IsInGirlQuiz
    {
        get
        {
            return isInGirlQuiz;
        }
    }

    public void InteractionProcess()
    {
        EventsBroker.StopHuntingFoPlayer();
        isInGirlQuiz = true;
        UIManager.Instance.quizScreen.SetActive(true);
    }
    
    public void RepeatPatrolMoving()
    {
        isInGirlQuiz = false;
        Invoke("PatrolStateReturn", delayToReturnPatol);
    }

    private void PatrolStateReturn()
    {
        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }

}
