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
        PlayerButtonPressed(); //NeedFix ������ ����� ��� ���� �� ������ � �����, � �� �����
    }

    public void PlayerButtonPressed()
    {
        //NeedFix ����������� ������������ AUDIO
        print("�������� ���������");
        NpcController[] allNpc = FindObjectsOfType<NpcController>();
        foreach (var npc in allNpc)        
            npc.TransitionToState(new EscapeState(npc.periodPanic));        
    }

    void RestartGame()
    {
        meshRenderer.material = glassFine;
    }
}
