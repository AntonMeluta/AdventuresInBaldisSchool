using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldisInteraction : MonoBehaviour, IInteractionPlayerAI
{
    NpcController npcController;

    public GameObject lossWindow;
    public float delayToRestart = 5;

    void OnEnable()
    {

    }

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
        GameManager.Instance.UpdateGameState(GameManager.GameState.pregame);
    }

    //NeedFix �� ������ �����������! ��� ������
    void MethodForEventLossGame()
    {
        lossWindow.SetActive(false);
    }

}
