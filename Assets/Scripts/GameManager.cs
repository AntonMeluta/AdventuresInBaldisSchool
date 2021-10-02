using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    GameState currentState = GameState.pregame;
    GameMode gameMode;

    public enum GameMode
    {
        standart,
        sandbox
    }
    public enum GameState
    {
        pregame,
        menu,
        pause,
        game,
        /*pantsOnHeadMiniGame,
        penaltyPlayer,*/
        //quiz
        //loss
    }

    private void Start()
    {
        UpdateGameState(GameState.pregame);
    }

    public GameMode CurrentGameMode
    {
        get
        {
            return gameMode;
        }
    }

    //�������� ���� ���������� ������ �� �������
    private void InitGameData()
    {
        StatsManager.KeyBestScore = "BestScoreSandboxMode";
        StatsManager.Key�omplexityGame = "�omplexityGame";
        StatsManager.LoadResult();
        StatsManager.Load�omplexityValue();
    }
    
    //���������� ����� ����� ��� ������ � ���������� ��������� ����
    public void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;       

        switch (state)
        {
            case GameState.pregame:
                InitGameData();
                Time.timeScale = 0;
                break;
            case GameState.menu:
                AudioController.Instance.StopMusicGame();                
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
            /*case GameState.pantsOnHeadMiniGame:
                Time.timeScale = 1;
                break;
            case GameState.penaltyPlayer:
                Time.timeScale = 1;
                break;*/
            /*case GameState.quiz:
                Time.timeScale = 1;
                break;
            case GameState.loss:
                Time.timeScale = 1;
                break;*/
            default:
                break;
        }

        EventsBroker.StartUpdateStateGameEvent(prevGameState, currentState);
    }
        
    public void UpdateGameMode(GameMode getGameMode)
    {
        gameMode = getGameMode;       
    }
}




