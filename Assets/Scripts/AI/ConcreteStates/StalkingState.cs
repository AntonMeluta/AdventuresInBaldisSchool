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
                Debug.Log("!!!!!!!! StalkingState Baldis !!!!!!!!!!");
                npc.SetLayerDefault();
                break;
            case TypeAI.Principal:
                Debug.Log("!!!!!!!! StalkingState Principal !!!!!!!!!!");
                npc.SetLayerDefault();
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStop();
                break;
            case TypeAI.Bully:
                Debug.Log("!!!!!!!! StalkingState Bully !!!!!!!!!!");
                npc.SetLayerDefault();
                break;
            case TypeAI.Girl:
                Debug.Log("!!!!!!!! StalkingState Girl !!!!!!!!!!");
                break;
            case TypeAI.Rider:
                Debug.Log("!!!!!!!! StalkingState Rider !!!!!!!!!!");
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
        //�������� ������������ � �������
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //����� ������ ��������������, � ������ ������� ������ ����������
            if (npc.GetComponent(typeof(IInteractionPlayerAI)))
            {
                npc.TransitionToState(npc.idleState);
                npc.GetComponent<IInteractionPlayerAI>().InteractionProcess();                
            }
        }
    }
}
