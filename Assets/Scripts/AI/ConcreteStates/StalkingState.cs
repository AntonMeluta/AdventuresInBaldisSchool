using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkingState : NpcBaseState
{

    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.evilFace);
        npc.StartStalking();
    }
    public override bool CanSeePlayer(NpcController npc)
    {
        throw new System.NotImplementedException();
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
                npc.GetComponent<IInteractionPlayerAI>().InteractionProcess();
                npc.TransitionToState(npc.idleState);
            }
        }
    }
}
