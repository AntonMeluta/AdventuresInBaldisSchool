using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatShop : MonoBehaviour
{
    public GameObject energieBar;
    
    public void BuyChokolate()
    {
        energieBar.SetActive(true);
    }
}
