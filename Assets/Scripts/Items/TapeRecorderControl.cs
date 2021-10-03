using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeRecorderControl : MonoBehaviour
{
    public CameraControl cameraControl;

    public void DiscoStart()
    {
        AudioController.Instance.PlayMusic(SoundEffect.DiscoMusic);
        cameraControl.DiscoSchool(true);
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (var npc in allNpc)
            npc.TransitionToState(new DanceState(npc.periodDance));
    }
}
