using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyPlayerScreen : MonoBehaviour
{
    private int delayPenalty;
    
    public Text timeTextPenalty;

    private void OnEnable()
    {
        StartCoroutine(TimingPenalty());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetValueDelay(int delay)
    {
        delayPenalty = delay;
    }

    private IEnumerator TimingPenalty()
    {
        timeTextPenalty.text = delayPenalty.ToString();

        while (delayPenalty > 0)
        {
            yield return new WaitForSeconds(1);

            delayPenalty--;
            timeTextPenalty.text = delayPenalty.ToString();
        }

        gameObject.SetActive(false);
    }

}
