using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    public Button pauseButton;
    public Button toMenuButton;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseButtonAction);
        toMenuButton.onClick.AddListener(ToMenuButtonAction);
    }

    private void PauseButtonAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.pause);
    }

    private void ToMenuButtonAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }

}
