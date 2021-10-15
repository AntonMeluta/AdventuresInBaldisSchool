using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookAction : MonoBehaviour, IItemUsing, IInteractiveWithPlayer
{

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
        UIManager.Instance.quizScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
