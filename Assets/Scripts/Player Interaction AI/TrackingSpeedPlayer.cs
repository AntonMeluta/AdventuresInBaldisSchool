using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSpeedPlayer : MonoBehaviour
{
    float distanceToPlayer = 0;
    NpcController npc;
    bool isPenaltyPlayer;

    public float rangeCheckPlayer = 60;

    public RigidbodyFirstPersonController fpsPlayer;
    public float intervalToCheck = 0.2f;

    private void Start()
    {
        npc = GetComponent<NpcController>();
        isPenaltyPlayer = false;
    }

    public void UpdateStatusPenalty()
    {
        isPenaltyPlayer = !isPenaltyPlayer;
    }

    public void CheckPlayerSpeedStart()
    {
        StartCoroutine(CheckPlayerSpeed());
    }

    public void CheckPlayerSpeedStop()
    {
        StopAllCoroutines();
    }
    
    IEnumerator CheckPlayerSpeed()
    {
        float dangerSpeedBorderPlayer = 10;
        while (true)
        {
            yield return new WaitForSeconds(intervalToCheck);

            distanceToPlayer = Vector3.Distance(transform.position, fpsPlayer.transform.position);
            if (!isPenaltyPlayer && distanceToPlayer <= rangeCheckPlayer &&
                fpsPlayer.movementSettings.CurrentTargetSpeed > dangerSpeedBorderPlayer)
            {
                npc.TransitionToState(npc.stalkingState);
                break;
            }
        }
    }

}
