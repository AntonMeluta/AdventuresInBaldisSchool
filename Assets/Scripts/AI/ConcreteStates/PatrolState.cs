using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : NpcBaseState
{
    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.goodFace);
        npc.StartPatrolling();

        switch (npc.typeAi)
        {
            case TypeAI.Baldis:
                break;
            case TypeAI.Principal:
                npc.SetLayerNotCOllisionPlayer();
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStart();
                break;
            case TypeAI.Bully:
                npc.SetLayerNotCOllisionPlayer();
                break;
            case TypeAI.Girl:
                npc.SetLayerDefault();
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
        //Проверка столкновения с игроком
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Вызов метода взаимодействия, в случае наличия такого компонента
            if (npc.GetComponent(typeof(IInteractionPlayerAI)))
            {
                npc.GetComponent<IInteractionPlayerAI>().InteractionProcess();
                npc.TransitionToState(npc.idleState);
            }
        }
    }


}
