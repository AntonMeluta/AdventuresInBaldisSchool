using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePointControl : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        EventsBroker.EventRestartGame += RestartGame;
    }

    public void EscapeActivated()
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = true;
    }

    private void RestartGame()
    {
        meshRenderer.enabled = true;
        boxCollider.enabled = false;
    }
}
