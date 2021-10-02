using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuationButton : MonoBehaviour
{
    MeshRenderer meshRenderer;

    public Material glassFine;
    public Material glassBroken;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = glassFine;
    }

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= RestartGame;
    }

    public void PlayerBrokenGlass()
    {
        meshRenderer.material = glassBroken;
        PlayerButtonPressed(); //NeedFix делать вызов при тапе по кнопке в сцене, а не сразу
    }

    public void PlayerButtonPressed()
    {
        AudioController.Instance.PlaySoundEffect(SoundEffect.CrashGlass);
        AudioController.Instance.PlayMusic(SoundEffect.AlarmFire);        
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        Camera.main.GetComponent<CameraControl>().WaterDropEffect(true);
        foreach (var npc in allNpc)        
            npc.TransitionToState(new EscapeState(npc.periodPanic));
    }

    private void RestartGame()
    {
        meshRenderer.material = glassFine;
    }
}
