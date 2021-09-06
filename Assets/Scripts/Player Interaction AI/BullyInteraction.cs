using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    public Transform playerPos;
    public Transform toilet;
   
    public void InteractionProcess()
    {
        Transform player = GameObject.FindObjectOfType<PlayerController>().transform;
        GameManager.Instance.UpdateGameState(GameManager.GameState.pantsOnHeadMiniGame);
        playerPos.position = toilet.position;

        /*NpcController npc = GetComponent<NpcController>();
        npc.TransitionToState(npc.patrolState);*/
        EventsBroker.StopHuntingFoPlayer();
    }


}
