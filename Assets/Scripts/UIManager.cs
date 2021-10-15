using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject preGameWindow;
    public GameObject selectModeMenu;
    public GameObject pauseMenu;
    public GameObject gameplayMenu;
    public GameObject inventary;
    public GameObject notebooksCounter;
    public GameObject textToWin;
    public GameObject pantsOnHeadGame;
    public GameObject penaltyPlayerScreen;
    public GameObject quizScreen;
    public GameObject lossScreen;
    public GameObject winScreen;

    private void OnEnable()
    {
        EventsBroker.UpdateStateGameEvent += StartGameOrPregameSetState;
    }

    private void OnDisable()
    {
        EventsBroker.UpdateStateGameEvent -= StartGameOrPregameSetState;
    }

    private void StartGameOrPregameSetState(GameManager.GameState oldState, GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.pregame:
                preGameWindow.SetActive(true);
                selectModeMenu.SetActive(false);
                gameplayMenu.SetActive(false);
                break;
            case GameManager.GameState.menu:
                preGameWindow.SetActive(false);
                selectModeMenu.SetActive(true);
                gameplayMenu.SetActive(false);
                penaltyPlayerScreen.SetActive(false);
                pauseMenu.SetActive(false);
                quizScreen.SetActive(false);
                break;            
            case GameManager.GameState.game:
                selectModeMenu.SetActive(false);
                gameplayMenu.SetActive(true);
                pauseMenu.SetActive(false);
                pantsOnHeadGame.SetActive(false);
                break;
            case GameManager.GameState.pause:
                gameplayMenu.SetActive(false);
                pauseMenu.SetActive(true);
                break;
            default:
                break;
        }
    }


}
