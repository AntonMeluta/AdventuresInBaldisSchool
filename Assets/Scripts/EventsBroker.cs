using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsBroker
{

    //public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> {}

    #region ��������� �������� ���� 
    public delegate void UpdateStateGameDelegate(GameManager.GameState oldState, GameManager.GameState newState);
    public static event UpdateStateGameDelegate UpdateStateGameEvent;
    public static void StartUpdateStateGameEvent(GameManager.GameState oldState, GameManager.GameState newState)
    {
        UpdateStateGameEvent?.Invoke(oldState, newState);
    }
    #endregion

    #region ������� - ������� ����
    public static Action EventRestartGame;
    public static void RestartGameSend()
    {
        HuntingForPlayerRestart = null;
        EventRestartGame?.Invoke();
    }
    #endregion

    #region ����� ������� ���-����, ���������� ����� (�� ����������� �������)
    public static Action HuntingForPlayerStopEvent;
    public static void StopHuntingFoPlayer()
    {
        HuntingForPlayerStopEvent?.Invoke();
    }
    #endregion

    #region ���������� �����, ���� ������� �� ������� ������
    public static Action HuntingForPlayerRestart;
    public static void RestartHuntingForPlayer()
    {
        HuntingForPlayerRestart?.Invoke();
    }
    #endregion


}
