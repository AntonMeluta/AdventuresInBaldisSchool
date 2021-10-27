using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PregameSceen : MonoBehaviour
{
    private GameManager gameManager;

    public Button startGame;
    public Button moreGames;

    [SerializeField]private string moreGameRedirectRef;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
    }

    private void Start()
    {
        startGame.onClick.AddListener(StartGameAction);
        moreGames.onClick.AddListener(MoreGamesAction);
    }

    private void StartGameAction()
    {
        gameManager.UpdateGameState(GameManager.GameState.menu);
    }

    private void MoreGamesAction()
    {
        Application.OpenURL(moreGameRedirectRef);
    }

}
