using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += RestartPositionPlayer;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= RestartPositionPlayer;
    }

    private void RestartPositionPlayer()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NpcController npc = FindObjectOfType<NpcController>();
            npc.TransitionToState(npc.patrolState);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            NpcController npc = FindObjectOfType<NpcController>();
            npc.TransitionToState(npc.stalkingState);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NpcController npc = FindObjectOfType<NpcController>();
            npc.TransitionToState(new EscapeState(30));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            NpcController npc = FindObjectOfType<NpcController>();
            npc.TransitionToState(new LessonBeginState(30));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            NpcController npc = FindObjectOfType<NpcController>();
            npc.TransitionToState(npc.idleState);
        }
    }
}
