using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : NpcBaseState
{
    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.goodFace);
        npc.StopMoving();
        npc.SetLayerNotCOllisionPlayer();

        switch (npc.typeAi)
        {
            case TypeAI.Baldis:
                break;
            case TypeAI.Principal:
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStop();
                break;
            case TypeAI.Bully:
                break;
            case TypeAI.Girl:
                break;
            case TypeAI.Rider:
                break;
            default:
                break;
        }
    }

    public override void Update(NpcController npc)
    {

    }

    public override bool CanSeePlayer(NpcController npc)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {

    }



}
