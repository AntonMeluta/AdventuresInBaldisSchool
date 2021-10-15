using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyGame : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateValueDifficulty);
    }

    private void OnEnable()
    {
        slider.value = StatsManager.ComplexityGame;
    }

    private void UpdateValueDifficulty(float valueNew)
    {
        StatsManager.Save—omplexityValue((int)valueNew);
    }


}
