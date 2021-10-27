using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuScreen : MonoBehaviour
{
    private GameManager gameManager;

    public Text bestScoreText;
    public Button standartMode;
    public Button modeSandbox;
    public Button backButton;

    [SerializeField]private string moreGameRedirectRef;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
    }

    private void OnEnable()
    {
        bestScoreText.text = StatsManager.BestScore.ToString();
    }

    private void Start()
    {
        standartMode.onClick.AddListener(StandartModeStart);
        modeSandbox.onClick.AddListener(SandboxModeStart);
        backButton.onClick.AddListener(BackButtonMenu);
    }

    private void StandartModeStart()
    {
        gameManager.UpdateGameMode(GameManager.GameMode.standart);
        gameManager.UpdateGameState(GameManager.GameState.game);
    }

    private void SandboxModeStart()
    {
        gameManager.UpdateGameMode(GameManager.GameMode.sandbox);
        gameManager.UpdateGameState(GameManager.GameState.game);
    }

    private void BackButtonMenu()
    {
        gameManager.UpdateGameState(GameManager.GameState.pregame);
    }

}
