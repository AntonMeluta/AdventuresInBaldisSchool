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
        game
    }

    private void Start()
    {
        UpdateGameState(GameState.pregame);
    }

    //Глобальная точка входа для работы с изменением состояния игры
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


