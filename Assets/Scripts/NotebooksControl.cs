using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebooksControl : MonoBehaviour
{
    int countPickupedNotebooks = 0;

    public GameObject[] allNotebooksInScene;

    private int countNotebooksStandart;
    public Text notebooksPickupedText;

    private void Awake()
    {
        countNotebooksStandart = allNotebooksInScene.Length;
    }

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += ResetStatusNotebooks;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= ResetStatusNotebooks;
    }

    public void ResetStatusNotebooks()
    {
        countPickupedNotebooks = 0;
        for (int i = 0; i < allNotebooksInScene.Length; i++)
            allNotebooksInScene[i].SetActive(true);

        switch (GameManager.Instance.CurrentGameMode)
        {
            case GameManager.GameMode.standart:
                notebooksPickupedText.text = countPickupedNotebooks + "/" + countNotebooksStandart;
                break;
            case GameManager.GameMode.sandbox:
                notebooksPickupedText.text = countPickupedNotebooks.ToString();
                break;
            default:
                break;
        }       
    }

    public void PlayerPickupNotebook()
    {
        countPickupedNotebooks++;
        switch (GameManager.Instance.CurrentGameMode)
        {
            case GameManager.GameMode.standart:
                UpdateScoreInStandartMode();
                break;
            case GameManager.GameMode.sandbox:
                UpdateScoreInSandboxMode();
                break;
            default:
                break;
        }
    }

    private void UpdateScoreInStandartMode()
    {
        notebooksPickupedText.text = countPickupedNotebooks + "/9";
        if (countPickupedNotebooks == countNotebooksStandart)
            print("Открыть эвауационный выход");  //NeedFix
    }

    private void UpdateScoreInSandboxMode()
    {
        notebooksPickupedText.text = countPickupedNotebooks.ToString();
        StatsManager.SaveResult(countPickupedNotebooks);
    }
}
