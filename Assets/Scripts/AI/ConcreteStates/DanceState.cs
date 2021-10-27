using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceState : NpcBaseState
{
    AudioController audioController;
    private float durationLessons;
    private float time;

    public DanceState(int timeLessons, AudioController audio)
    {
        audioController = audio;
        durationLessons = timeLessons;
    }

    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.goodFace);
        npc.DancingNpc();
        npc.SetLayerNotCOllisionPlayer();

        switch (npc.typeAi)
        {
            case TypeAI.Baldis:
                break;
            case TypeAI.Principal:
                npc.GetComponent<TrackingSpeedPlayer>().CheckPlayerSpeedStop();
                break;
            case TypeAI.Bully:
                break;
            case TypeAI.Girl:
                break;
            case TypeAI.Rider:
                break;
            default:
                break;
        }
    }

    public override void Update(NpcController npc)
    {
        time += Time.deltaTime;
        if (time > durationLessons)
        {
            npc.ReturnToPrevState();
            audioController.PlayMusic(SoundEffect.MainTheme);
            npc.danceCicrle.SetActive(false);
            Camera.main.GetComponent<CameraControl>().DiscoSchool(false);
        }
    }

    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {

    }
}
