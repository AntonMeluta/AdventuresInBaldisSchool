using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    public GameObject[] controllersPrefabs;

    private AudioController audioController;

    private GameState currentState = GameState.pregame;
    private GameMode gameMode;

    [Inject]
    private void ConstructorLike(AudioController audio)
    {
        audioController = audio;
    }

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
    }

    private void Start()
    {
        /*foreach (GameObject controller in controllersPrefabs)
        {
            Instantiate(controller);
        }    */    
        UpdateGameState(GameState.pregame);
    }

    public GameMode CurrentGameMode
    {
        get
        {
            return gameMode;
        }
    }

    //Загрузка всех сохранённых данных из реестра
    private void InitGameData()
    {
        StatsManager.LoadResult();
        StatsManager.LoadСomplexityValue();
    }
    
    //Глобальная точка входа для работы с изменением состояния игры
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
                audioController.StopMusicGame();                
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
        
    public void UpdateGameMode(GameMode getGameMode)
    {
        gameMode = getGameMode;       
    }
}




