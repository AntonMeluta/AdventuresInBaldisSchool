using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
