using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    GameState currentState = GameState.pregame;

    public enum GameState
    {
        pregame,
        menu,
        pause,
        game,
        pantsOnHeadMiniGame,
        penaltyPlayer,
        quiz
    }

    private void Start()
    {
        UpdateGameState(GameState.pregame);
    }

    //���������� ����� ����� ��� ������ � ���������� ��������� ����
    public void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;       

        switch (state)
        {
            case GameState.pregame:
                Time.timeScale = 0;
                break;
            case GameState.menu:
                Time.timeScale = 0;
                break;
            case GameState.game:
                Time.timeScale = 1;
                if (prevGameState == GameState.menu)
                    EventsBroker.RestartGameSend();     //SceneManager.LoadScene(0);  
                break;
            case GameState.pause:
                Time.timeScale = 0;
                break;
            case GameState.pantsOnHeadMiniGame:
                Time.timeScale = 1;
                break;
            case GameState.penaltyPlayer:
                Time.timeScale = 1;
                break;
            case GameState.quiz:
                Time.timeScale = 1;
                break;
            default:
                break;
        }

        EventsBroker.StartUpdateStateGameEvent(prevGameState, currentState);
    }
}

public enum TypeAI
{
    Baldis,
    Principal,
    Bully,
    Girl,
    Rider
}


