using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonBeginState : NpcBaseState
{
    float durationLessons;
    float time;

    public LessonBeginState(int timeLessons)
    {
        durationLessons = timeLessons;
    }

    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.evilFace);
        Transform evacuationPoint = GameObject.Find("BuzzerToCabinet").transform;
        npc.ToPointSpecial(evacuationPoint);
    }

    public override void Update(NpcController npc)
    {
        time += Time.deltaTime;
        Debug.Log("time = " + time);
        if (time > durationLessons)
            npc.TransitionToState(npc.patrolState);
    }

    public override bool CanSeePlayer(NpcController npc)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {
        
    }
}
