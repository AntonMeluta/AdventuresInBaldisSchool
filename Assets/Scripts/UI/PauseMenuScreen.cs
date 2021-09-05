using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScreen : MonoBehaviour
{
    public Button pauseButton;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseButtonAction);
    }

    void PauseButtonAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
    }
}
