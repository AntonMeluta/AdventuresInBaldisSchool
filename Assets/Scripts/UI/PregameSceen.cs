using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PregameSceen : MonoBehaviour
{
    public Button startGame;
    public Button moreGames;

    public string moreGameRedirectRef;

    private void Start()
    {
        startGame.onClick.AddListener(StartGameAction);
        moreGames.onClick.AddListener(MoreGamesAction);
    }

    void StartGameAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.menu);
    }

    void MoreGamesAction()
    {
        Application.OpenURL(moreGameRedirectRef);
    }

}
