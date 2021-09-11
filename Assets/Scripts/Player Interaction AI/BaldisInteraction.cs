using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldisInteraction : MonoBehaviour, IInteractionPlayerAI
{
    NpcController npcController;

    public GameObject lossWindow;
    public float delayToRestart = 5;

   
    void Start()
    {
        npcController = GetComponent<NpcController>();
    }
    
    public void InteractionProcess()
    {
        lossWindow.SetActive(true);
        EventsBroker.StopHuntingFoPlayer();
        Invoke("EndGame", delayToRestart);
        
    }

    void EndGame()
    {
        lossWindow.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }
    
}
