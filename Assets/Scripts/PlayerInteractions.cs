using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    //InventarObject NeedFix
    float distanceRay = 1.5f;

    public InventoryControl inventoryControl;
    public LayerMask needLayerCast;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay, needLayerCast))
        {
            inventoryControl.AddItem(hit.transform.GetComponent<IInventoryItem>(),
                hit.transform.gameObject);
        }
    }
}
