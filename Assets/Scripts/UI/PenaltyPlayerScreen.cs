using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyPlayerScreen : MonoBehaviour
{
    int delayPenalty;

    public GameObject doorLocker;
    public Text timeTextPenalty;

    private void OnEnable()
    {
        doorLocker.SetActive(true);
        StartCoroutine(TimingPenalty());
    }

    private void OnDisable()
    {
        doorLocker.SetActive(false);
        StopAllCoroutines();
    }

    public void SetValueDelay(int delay)
    {
        delayPenalty = delay;
    }

    IEnumerator TimingPenalty()
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
