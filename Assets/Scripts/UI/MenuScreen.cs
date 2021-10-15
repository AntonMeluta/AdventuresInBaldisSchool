using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    public Text bestScoreText;
    public Button standartMode;
    public Button modeSandbox;
    public Button backButton;

    [SerializeField]string moreGameRedirectRef;

    private void OnEnable()
    {
        //NeeedFix ...
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
        GameManager.Instance.UpdateGameMode(GameManager.GameMode.standart);
        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
    }

    private void SandboxModeStart()
    {
        GameManager.Instance.UpdateGameMode(GameManager.GameMode.sandbox);
        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
    }

    private void BackButtonMenu()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.pregame);
    }

}
