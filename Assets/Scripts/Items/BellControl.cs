using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellControl : MonoBehaviour
{
    MeshRenderer meshRenderer;

    public Material withoutBattaries;
    public Material withBataries;

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
        AudioController.Instance.PlayMusic(SoundEffect.BellToLean);
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (var npc in allNpc)
        {
            npc.SaveCurentState();
            npc.TransitionToState(new LessonBeginState(npc.periodLesson));
        }
            
    }

    private void RestartGame()
    {
        meshRenderer.material = withoutBattaries;
    }
}
