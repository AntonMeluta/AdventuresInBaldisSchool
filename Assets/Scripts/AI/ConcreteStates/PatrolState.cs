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
                Debug.Log("!!!!!!!! PatrolState Baldis !!!!!!!!!!");
                break;
            case TypeAI.Principal:
                npc.SetLayerNotCOllisionPlayer();
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStart();
                Debug.Log("!!!!!!!! PatrolState Principal !!!!!!!!!!");
                break;
            case TypeAI.Bully:
                npc.SetLayerNotCOllisionPlayer();
                Debug.Log("!!!!!!!! PatrolState Bully !!!!!!!!!!");
                break;
            case TypeAI.Girl:
                npc.SetLayerDefault();
                Debug.Log("!!!!!!!! PatrolState Girl !!!!!!!!!!");
                break;
            case TypeAI.Rider:
                Debug.Log("!!!!!!!! PatrolState Rider !!!!!!!!!!");
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
