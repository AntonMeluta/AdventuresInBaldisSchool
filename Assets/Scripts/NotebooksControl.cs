using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NotebooksControl : MonoBehaviour
{
    private int countPickupedNotebooks = 0;
    private GameManager gameManager;
    private UIManager uIManager;
    private AudioController audioController;

    public GameObject[] allNotebooksInScene;
    private int countNotebooksStandart;
    
    public EscapePointControl pointControl;

    private CameraControl cameraControl;

    [Inject]
    private void ConstructorLike(PlayerController playerController, 
        GameManager gm, UIManager ui, AudioController audio)
    {
        cameraControl = playerController.GetComponentInChildren<CameraControl>();
        gameManager = gm;
        uIManager = ui;
        audioController = audio;
    }

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

        switch (gameManager.CurrentGameMode)
        {
            case GameManager.GameMode.standart:
                uIManager.notebooksCounter.GetComponentInChildren<Text>().text = 
                    countPickupedNotebooks + "/" + countNotebooksStandart;
                break;
            case GameManager.GameMode.sandbox:
                uIManager.notebooksCounter.GetComponentInChildren<Text>().text =
                    countPickupedNotebooks.ToString();
                break;
            default:
                break;
        }

        uIManager.notebooksCounter.SetActive(true);
        uIManager.textToWin.SetActive(false);
    }

    public void PlayerPickupNotebook()
    {
        countPickupedNotebooks++;

        switch (gameManager.CurrentGameMode)
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
        uIManager.notebooksCounter.GetComponentInChildren<Text>().text =
            countPickupedNotebooks + "/" + countNotebooksStandart;

        if (countPickupedNotebooks == /*countNotebooksStandart*/ 1)
        {
            uIManager.textToWin.SetActive(true);
            uIManager.notebooksCounter.SetActive(false);
            pointControl.EscapeActivated();
            NpcController[] allNpc = FindObjectsOfType<NpcController>();
            audioController.PlayMusic(SoundEffect.DangerSound);
            cameraControl.DangerModeCam();
            foreach (NpcController npc in allNpc)
                npc.TransitionToState(npc.stalkingState);
        }
            
    }

    private void UpdateScoreInSandboxMode()
    {
        uIManager.notebooksCounter.GetComponentInChildren<Text>().text =
            countPickupedNotebooks.ToString();

        StatsManager.SaveResult(countPickupedNotebooks);
    }
}
