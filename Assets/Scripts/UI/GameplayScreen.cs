using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    private bool isIconRun;

    public Button pauseButton;
    public Button toMenuButton;
    public Button runButton;
    public Image runButtonImage;
    public Sprite walkIcon;
    public Sprite runIcon;
    public RigidbodyFirstPersonController personController;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseButtonAction);
        toMenuButton.onClick.AddListener(ToMenuButtonAction);
        runButton.onClick.AddListener(TapRunButton);        
        EventsBroker.EventRestartGame += RestartGame;
        RestartGame();
    }

    private void RestartGame()
    {
        isIconRun = false;
        runButtonImage.sprite = walkIcon;
        personController.ChangeSpeedPlayer(isIconRun);
    }

    private void PauseButtonAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.pause);
    }

    private void ToMenuButtonAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }

    private void TapRunButton()
    {
        isIconRun = !isIconRun;
        runButtonImage.sprite = isIconRun ? runIcon : walkIcon;
        personController.ChangeSpeedPlayer(isIconRun);
    }

}
