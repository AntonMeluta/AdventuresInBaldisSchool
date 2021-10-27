using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayScreen : MonoBehaviour
{
    private GameManager gameManager;

    private bool isIconRun;
    private RigidbodyFirstPersonController personController;

    public Button pauseButton;
    public Button toMenuButton;
    public Button runButton;
    public Image runButtonImage;
    public Sprite walkIcon;
    public Sprite runIcon;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
    }

    private void Start()
    {
        personController = FindObjectOfType<RigidbodyFirstPersonController>();
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
        gameManager.UpdateGameState(GameManager.GameState.pause);
    }

    private void ToMenuButtonAction()
    {
        gameManager.UpdateGameState(GameManager.GameState.menu);
    }

    private void TapRunButton()
    {
        isIconRun = !isIconRun;
        runButtonImage.sprite = isIconRun ? runIcon : walkIcon;
        personController.ChangeSpeedPlayer(isIconRun);
    }

}
