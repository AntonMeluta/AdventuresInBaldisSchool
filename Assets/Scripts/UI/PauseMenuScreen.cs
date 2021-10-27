using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseMenuScreen : MonoBehaviour
{
    private GameManager gameManager;

    public Button pauseButton;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseButtonAction);
    }

    private void PauseButtonAction()
    {
        gameManager.UpdateGameState(GameManager.GameState.game);
    }
}
