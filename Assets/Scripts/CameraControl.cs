using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public ParentCamEffects[] camEffects;
    public ParentCamEffects waterDrop;
    public ParentCamEffects discoEffect;

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += NormalModeCam;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= NormalModeCam;
    }

    public void NormalModeCam()
    {
        foreach (ParentCamEffects effect in camEffects)
            effect.enabled = false;
        waterDrop.enabled = false;
        discoEffect.enabled = false;
    }

    public void DangerModeCam()
    {
        foreach (ParentCamEffects effect in camEffects)
            effect.enabled = true;
    }

    public void WaterDropEffect(bool isEnabled)
    {
        waterDrop.enabled = isEnabled;
    }

    public void DiscoSchool(bool isEnabled)
    {
        discoEffect.enabled = isEnabled;
    }
}
