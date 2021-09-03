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
        Invoke("EndGame", delayToRestart);

    }

    void EndGame()
    {
        //NeedFix рестарт игры
        GameManager.Instance.UpdateGameState(GameManager.GameState.pregame);
    }
    
}
