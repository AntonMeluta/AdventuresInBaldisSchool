using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BellControl : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private AudioController audioController;

    public Material withoutBattaries;
    public Material withBataries;

    [Inject]
    private void ConstructorLike(AudioController audio)
    {
        audioController = audio;
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = withoutBattaries;
    }

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= RestartGame;
    }

    public void PlayerPutBattaries()
    {
        meshRenderer.material = withBataries;
        PlayerTapBell(); //NeedFix
    }

    public void PlayerTapBell()
    {
        audioController.PlayMusic(SoundEffect.BellToLean);
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (var npc in allNpc)
        {
            npc.SaveCurentState();
            npc.TransitionToState(new LessonBeginState(npc.PeriodLesson, audioController));
        }
            
    }

    private void RestartGame()
    {
        meshRenderer.material = withoutBattaries;
    }
}
