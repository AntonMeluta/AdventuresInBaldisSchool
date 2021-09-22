using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookAction : MonoBehaviour, IItemUsing, IInteractiveWithPlayer
{
    public GameObject quizScreen;

    private void Start()
    {
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        gameObject.SetActive(true);
    }

    public void InteractionOccurred()
    {
        ItemUsedUp();
    }

    public void ItemUsedUp()
    {
        EventsBroker.StopHuntingFoPlayer();
        quizScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
