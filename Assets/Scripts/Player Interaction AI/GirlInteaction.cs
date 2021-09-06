using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlInteaction : MonoBehaviour, IInteractionPlayerAI
{
    int finishedAnswersCount;
    int countAllAnswers = 3;

    public float delayToRestartMoving = 30;
    public float increaseSpeedBaldis = 1;


    public void InteractionProcess()
    {
        finishedAnswersCount = 0;
        EventsBroker.StopHuntingFoPlayer();
        GameManager.Instance.UpdateGameState(GameManager.GameState.quiz);
        Invoke("RepeatPatrolMoving", delayToRestartMoving);
    }

    //����� ������ � ������
    /*public void FailureInteraction()
    {
        FindObjectOfType<BaldisInteraction>().GetComponent<NavMeshAgent>().speed += increaseSpeedBaldis;
        finishedAnswersCount++;

        if (finishedAnswersCount >= countAllAnswers)
        {
            NpcController baldis = FindObjectOfType<BaldisInteraction>().GetComponent<NpcController>();
            baldis.TransitionToState(baldis.stalkingState);

            windowWithQuestinos.SetActive(false);
            
        }
                
    }

    //����� ��������� �������
    public void ConflictInteraction()
    {
        windowWithQuestinos.SetActive(false);

        //����� �������� �������, � ���� �������� ����� �� ������
        
        Invoke("RepeatPatrolMoving", delayToRestartMoving);
    }

    //����� ������������ � ����� ��� ������
    public void PlayerFriendly()
    {
        windowWithQuestinos.SetActive(false);
        Invoke("RepeatPatrolMoving", delayToRestartMoving);
    }*/

    void RepeatPatrolMoving()
    {
        NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);
    }

}
