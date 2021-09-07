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
        //NeedFix
        //lossWindow.SetActive(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.loss);
        Invoke("EndGame", delayToRestart);
        EventsBroker.StopHuntingFoPlayer();
    }

    void EndGame()
    {
        //lossWindow.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }
    
}
