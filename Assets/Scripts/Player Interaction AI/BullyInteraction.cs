using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyInteraction : MonoBehaviour, IInteractionPlayerAI
{
    public Transform playerPos;
    public Transform toilet;

    public GameObject pantsOnHeadScreen;

    public void InteractionProcess()
    {
        EventsBroker.StopHuntingFoPlayer();

        Transform player = GameObject.FindObjectOfType<PlayerController>().transform;        
        playerPos.position = toilet.position;
        pantsOnHeadScreen.SetActive(true);
    }


}
