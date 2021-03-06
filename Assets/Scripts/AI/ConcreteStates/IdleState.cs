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
                Debug.Log("!!!!!!!! IdleState Baldis !!!!!!!!!!");
                break;
            case TypeAI.Principal:
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStop();
                Debug.Log("!!!!!!!! IdleState Principal !!!!!!!!!!");
                break;
            case TypeAI.Bully:
                Debug.Log("!!!!!!!! IdleState Bully!!!!!!!!!!");
                break;
            case TypeAI.Girl:
                Debug.Log("!!!!!!!! IdleState Girl !!!!!!!!!!");
                break;
            case TypeAI.Rider:
                Debug.Log("!!!!!!!! IdleState Rider !!!!!!!!!!");
                break;
            default:
                break;
        }
    }

    public override void Update(NpcController npc)
    {

    }
    
    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {

    }
    
}
