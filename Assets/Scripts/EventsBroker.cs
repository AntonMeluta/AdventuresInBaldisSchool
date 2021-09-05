using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsBroker
{

    //public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> {}

    #region Изменение остояния игры 
    public delegate void UpdateStateGameDelegate(GameManager.GameState oldState, GameManager.GameState newState);
    public static event UpdateStateGameDelegate UpdateStateGameEvent;
    public static void StartUpdateStateGameEvent(GameManager.GameState oldState, GameManager.GameState newState)
    {
        UpdateStateGameEvent?.Invoke(oldState, newState);
    }
    #endregion

    #region Рестарт игры
    public static Action EventRestartGame;
    public static void RestartGameSend()
    {
        EventRestartGame?.Invoke();
    }
    #endregion

}
