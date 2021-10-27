using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInteractions : MonoBehaviour
{
    private GameManager gameManager;
    private UIManager uiManager;
    private AudioController audioController;

    private float distanceRay = 1.5f;
    private float delayToRestart = 8;

    public InventoryControl inventoryControl;
    public LayerMask needLayerCast;

    [Inject]
    private void ConstructorLike(UIManager ui, AudioController audio, GameManager gm)
    {
        uiManager = ui;
        audioController = audio;
        gameManager = gm;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay, needLayerCast))
        {
            hit.transform.GetComponent<IInteractiveWithPlayer>().InteractionOccurred();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EscapePointControl>())
        {
            NpcController[] allNpc = FindObjectsOfType<NpcController>();
            foreach (NpcController npc in allNpc)
                npc.TransitionToState(npc.idleState);

            audioController.StopMusicGame();
            audioController.PlaySoundEffect(SoundEffect.WinSound);
            uiManager.winScreen.SetActive(true);
            Invoke("EndGame", delayToRestart);
        }
    }

    private void EndGame()
    {
        uiManager.winScreen.SetActive(false);
        gameManager.UpdateGameState(GameManager.GameState.menu);
    }
}

