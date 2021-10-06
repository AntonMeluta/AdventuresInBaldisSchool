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

    public GameObject textToWin;
    public GameObject notebooksCounterUi;
    public EscapePointControl pointControl;

    public CameraControl cameraControl;

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

        notebooksCounterUi.SetActive(true);
        textToWin.SetActive(false);
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
        if (countPickupedNotebooks == countNotebooksStandart) //NeedFix
        {
            textToWin.SetActive(true);
            notebooksCounterUi.SetActive(false);
            pointControl.EscapeActivated();
            NpcController[] allNpc = FindObjectsOfType<NpcController>();            
            AudioController.Instance.PlayMusic(SoundEffect.DangerSound);
            cameraControl.DangerModeCam();
            foreach (NpcController npc in allNpc)
                npc.TransitionToState(npc.stalkingState);
        }
            
    }

    private void UpdateScoreInSandboxMode()
    {
        notebooksPickupedText.text = countPickupedNotebooks.ToString();
        StatsManager.SaveResult(countPickupedNotebooks);
    }
}
