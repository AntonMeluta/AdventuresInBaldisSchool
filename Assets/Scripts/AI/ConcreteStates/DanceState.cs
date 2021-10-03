using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceState : NpcBaseState
{
    float durationLessons;
    float time;

    public DanceState(int timeLessons)
    {
        durationLessons = timeLessons;
    }

    public override void EnterState(NpcController npc)
    {
        npc.SetExpression(npc.goodFace);
        //Transform evacuationPoint = GameObject.Find("FirePanicExit").transform;
        npc.ToPointSpecial(npc.transform);
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
            AudioController.Instance.PlayMusic(SoundEffect.MainTheme);
            Camera.main.GetComponent<CameraControl>().DiscoSchool(false);
        }
    }

    public override void OnCollisionEnter(NpcController npc, Collision collision)
    {

    }
}
