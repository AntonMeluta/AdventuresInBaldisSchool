using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingFloat : MonoBehaviour
{
    private float rotation = 0;
    
    public void Update()
    {
        float amountToRotate = 1000 * Time.deltaTime;

        rotation += amountToRotate;
        int rand = Random.Range(0,2) == 0 ? 1 : -1;
        transform.Rotate(rand * Vector3.forward, amountToRotate);       
    }
}
