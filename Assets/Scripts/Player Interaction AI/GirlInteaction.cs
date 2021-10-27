using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class GirlInteaction : MonoBehaviour, IInteractionPlayerAI
{
    private float delayToReturnPatol = 10;
    private UIManager uIManager;

    [SerializeField]private float increaseSpeedBaldis = 1;
    [SerializeField]private bool isInGirlQuiz = false;

    [Inject]
    private void ConstructorLike(UIManager ui)
    {
        uIManager = ui;
    }

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
        uIManager.quizScreen.SetActive(true);
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
