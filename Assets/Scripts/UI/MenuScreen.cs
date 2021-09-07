using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{

    public Button standartMode;
    public Button modeSandbox;

    public string moreGameRedirectRef;

    private void Start()
    {
        standartMode.onClick.AddListener(StandartModeStart);
        modeSandbox.onClick.AddListener(SandboxModeStart);
    }

    void StandartModeStart()
    {
        GameManager.Instance.UpdateGameMode(GameManager.GameMode.standart);
        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
    }

    void SandboxModeStart()
    {
        GameManager.Instance.UpdateGameMode(GameManager.GameMode.sandbox);
        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
    }
}
