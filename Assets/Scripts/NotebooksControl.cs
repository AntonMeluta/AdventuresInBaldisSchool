using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebooksControl : MonoBehaviour
{
    int countPickupedNotebooks = 0;

    public GameObject[] allNotebooksInScene;
    private int countNotebooksStandart;
    
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
                UIManager.Instance.notebooksCounter.GetComponentInChildren<Text>().text = 
                    countPickupedNotebooks + "/" + countNotebooksStandart;
                break;
            case GameManager.GameMode.sandbox:
                UIManager.Instance.notebooksCounter.GetComponentInChildren<Text>().text =
                    countPickupedNotebooks.ToString();
                break;
            default:
                break;
        }

        UIManager.Instance.notebooksCounter.SetActive(true);
        UIManager.Instance.textToWin.SetActive(false);
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
        UIManager.Instance.notebooksCounter.GetComponentInChildren<Text>().text =
            countPickupedNotebooks + "/" + countNotebooksStandart;

        if (countPickupedNotebooks == /*countNotebooksStandart*/ 1)
        {
            UIManager.Instance.textToWin.SetActive(true);
            UIManager.Instance.notebooksCounter.SetActive(false);
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
        UIManager.Instance.notebooksCounter.GetComponentInChildren<Text>().text =
            countPickupedNotebooks.ToString();

        StatsManager.SaveResult(countPickupedNotebooks);
    }
}
