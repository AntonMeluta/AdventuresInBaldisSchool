using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NotebookAction : MonoBehaviour, IItemUsing, IInteractiveWithPlayer
{
    private UIManager uIManager;

    [Inject]
    private void ConstructorLike(UIManager ui)
    {
        uIManager = ui;
    }

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
        uIManager.quizScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
