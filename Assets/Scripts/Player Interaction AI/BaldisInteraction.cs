using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldisInteraction : MonoBehaviour, IInteractionPlayerAI
{
    NpcController npcController;

    public GameObject lossWindow;
    public float delayToRestart = 5;
   
    private void Start()
    {
        npcController = GetComponent<NpcController>();
    }
    
    public void InteractionProcess()
    {
        AudioController.Instance.StopMusicGame();
        AudioController.Instance.PlaySoundEffect(SoundEffect.LossSound);
        lossWindow.SetActive(true);
        Invoke("EndGame", delayToRestart);
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (NpcController npc in allNpc)
            npc.TransitionToState(npc.idleState);
    }

    private void EndGame()
    {
        lossWindow.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }
    
}
