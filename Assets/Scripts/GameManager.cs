using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    GameState currentState;
    public EventsBroker.EventGameState gameStateChanged;

    public enum GameState
    {
        pregame,
        menu,
        game
    }

    private void Start()
    {
        UpdateGameState(GameState.pregame);
    }

    void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;

        switch (state)
        {
            case GameState.pregame:
                break;
            case GameState.menu:
                break;
            case GameState.game:
                break;
            default:
                break;
        }
    }
}


