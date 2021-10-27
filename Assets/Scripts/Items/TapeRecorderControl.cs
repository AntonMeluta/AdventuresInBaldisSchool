using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TapeRecorderControl : MonoBehaviour
{
    private CameraControl cameraControl;
    private AudioController audioController;

    [Inject]
    private void ConstructorLike(PlayerController playerController)
    {
        cameraControl = playerController.GetComponentInChildren<CameraControl>();
    }

    [Inject]
    private void ConstructorLike(AudioController audio)
    {
        audioController = audio;
    }

    public void DiscoStart()
    {
        audioController.PlayMusic(SoundEffect.DiscoMusic);
        cameraControl.DiscoSchool(true);
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (var npc in allNpc)
        {
            npc.SaveCurentState();
            npc.TransitionToState(new DanceState(npc.PeriodDance, audioController));
        }            
    }
}
