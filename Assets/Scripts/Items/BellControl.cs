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
        PlayerTapBell(); //NeedFix делать вызов при тапе по кнопке в сцене, а не сразу
    }

    public void PlayerTapBell()
    {
        //NeedFix срабатывает сигнализация AUDIO
        print("ЗВОНОК НА УРОК ПРОЗВЕНЕЛ");
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (var npc in allNpc)
            npc.TransitionToState(new LessonBeginState(npc.periodLesson));
    }

    void RestartGame()
    {
        meshRenderer.material = withoutBattaries;
    }
}
