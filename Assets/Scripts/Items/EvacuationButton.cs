using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EvacuationButton : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private AudioController audioController;
    private CameraControl cameraControl;

    public Material glassFine;
    public Material glassBroken;

    [Inject]
    private void ConstructorLike(PlayerController playerController, AudioController audio)
    {
        cameraControl = playerController.GetComponentInChildren<CameraControl>();
        audioController = audio;
    }
    
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
        PlayerButtonPressed(); //NeedFix
    }

    public void PlayerButtonPressed()
    {
        audioController.PlaySoundEffect(SoundEffect.CrashGlass);
        audioController.PlayMusic(SoundEffect.AlarmFire);        
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        cameraControl.WaterDropEffect(true);
        foreach (var npc in allNpc)
        {
            npc.SaveCurentState();
            npc.TransitionToState(new EscapeState(npc.PeriodPanic, audioController));
        }    
            
    }

    private void RestartGame()
    {
        meshRenderer.material = glassFine;
    }
}
