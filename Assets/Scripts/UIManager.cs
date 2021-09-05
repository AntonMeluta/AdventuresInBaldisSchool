using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject preGameWindow;
    public GameObject selectModeMenu;
    public GameObject pauseMenu;
    public GameObject gameplayMenu;
    
    private void OnEnable()
    {
        EventsBroker.UpdateStateGameEvent += StartGameOrPregameSetState;
    }

    private void OnDisable()
    {
        EventsBroker.UpdateStateGameEvent -= StartGameOrPregameSetState;
    }

    void StartGameOrPregameSetState(GameManager.GameState oldState, GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.pregame:
                preGameWindow.SetActive(true);
                selectModeMenu.SetActive(false);
                gameplayMenu.SetActive(false);
                pauseMenu.SetActive(false);               
                break;
            case GameManager.GameState.menu:
                preGameWindow.SetActive(false);
                selectModeMenu.SetActive(true);
                gameplayMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;            
            case GameManager.GameState.game:
                preGameWindow.SetActive(false);
                selectModeMenu.SetActive(false);
                gameplayMenu.SetActive(true);
                pauseMenu.SetActive(false);
                break;
            case GameManager.GameState.pause:
                preGameWindow.SetActive(false);
                selectModeMenu.SetActive(false);
                gameplayMenu.SetActive(false);
                pauseMenu.SetActive(true);
                break;
            default:
                break;
        }
    }


}
