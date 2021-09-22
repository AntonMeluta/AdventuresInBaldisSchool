using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    float distanceRay = 1.5f;

    public InventoryControl inventoryControl;
    public LayerMask needLayerCast;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, distanceRay, needLayerCast))
        {
            hit.transform.GetComponent<IInteractiveWithPlayer>().InteractionOccurred();
        }
    }
}
