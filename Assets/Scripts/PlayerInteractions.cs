using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private float distanceRay = 1.5f;
    private float delayToRestart = 8;

    public InventoryControl inventoryControl;
    public LayerMask needLayerCast;

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

            AudioController.Instance.StopMusicGame();
            AudioController.Instance.PlaySoundEffect(SoundEffect.WinSound);
            UIManager.Instance.winScreen.SetActive(true);
            Invoke("EndGame", delayToRestart);
        }
    }

    private void EndGame()
    {
        UIManager.Instance.winScreen.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }
}

