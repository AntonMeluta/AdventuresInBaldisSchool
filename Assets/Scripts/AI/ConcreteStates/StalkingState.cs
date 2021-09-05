using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkingState : NpcBaseState
{

    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.evilFace);
        npc.StartStalking();

        switch (npc.typeAi)
        {
            case TypeAI.Baldis:
                npc.SetLayerDefault();
                break;
            case TypeAI.Principal:
                npc.SetLayerDefault();
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStop();
                break;
            case TypeAI.Bully:
                npc.SetLayerDefault();
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

    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {
        //Проверка столкновения с игроком
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Вызов метода взаимодействия, в случае наличия такого компонента
            if (npc.GetComponent(typeof(IInteractionPlayerAI)))
            {
                npc.TransitionToState(npc.idleState);
                npc.GetComponent<IInteractionPlayerAI>().InteractionProcess();                
            }
        }
    }
}
