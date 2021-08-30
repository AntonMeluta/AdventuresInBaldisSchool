using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsBroker
{

    [System.Serializable]
    public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> {}


    /*public static Action eventGameState;
    public static void CallAchivmentsResProgressCheck()
    {
        achievmentsResProgressCheck?.Invoke();
    }*/
}
