using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaldisInteraction : MonoBehaviour, IInteractionPlayerAI
{
    private NpcController npcController;
    private AudioController audioController;
    private UIManager uIManager;
    private GameManager gameManager;

    [SerializeField]private float delayToRestart = 5;

    [Inject]
    private void ConstructorLike(UIManager ui, AudioController audio, GameManager gm)
    {
        uIManager = ui;
        audioController = audio;
        gameManager = gm;
    }

    private void Start()
    {
        npcController = GetComponent<NpcController>();
    }
    
    public void InteractionProcess()
    {
        audioController.StopMusicGame();
        audioController.PlaySoundEffect(SoundEffect.LossSound);
        uIManager.lossScreen.SetActive(true);
        Invoke("EndGame", delayToRestart);
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (NpcController npc in allNpc)
            npc.TransitionToState(npc.idleState);
    }

    private void EndGame()
    {
        uIManager.lossScreen.SetActive(false);
        gameManager.UpdateGameState(GameManager.GameState.menu);
    }
    
}
