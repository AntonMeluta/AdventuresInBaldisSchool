using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : NpcBaseState
{
    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.goodFace);
        npc.StopMoving();
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
