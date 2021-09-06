using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaldisSpeedHelper : MonoBehaviour
{
    NavMeshAgent agent;
    NpcController npc;

    float speedDefault;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        npc = GetComponent<NpcController>();

        speedDefault = agent.speed;
    }

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += ResetToDefaultSpeed;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= ResetToDefaultSpeed;
    }

    public void IncreaseSpeedAgent(float increaseValue)
    {
        agent.speed += increaseValue;
        npc.TransitionToState(npc.stalkingState);
    }

    private void ResetToDefaultSpeed()
    {
        agent.speed = speedDefault;
    }
}
