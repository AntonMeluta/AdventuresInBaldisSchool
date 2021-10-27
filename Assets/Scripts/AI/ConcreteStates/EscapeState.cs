using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EscapeState : NpcBaseState
{
    private AudioController audioController;
    private float durationLessons;
    private float time;

    public EscapeState(int timeLessons, AudioController audio)
    {
        audioController = audio;
        durationLessons = timeLessons;
    }

    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.evilFace);
        Transform evacuationPoint = GameObject.Find("FirePanicExit").transform;
        npc.ToPointSpecial(evacuationPoint);
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
            Camera.main.GetComponent<CameraControl>().WaterDropEffect(false);
        }            
    }

    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {
        
    }
}
