using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSpeedPlayer : MonoBehaviour
{
    float distanceToPlayer = 0;
    NpcController npc;
    Rigidbody playerRigidbody;
    bool isPenaltyPlayer;

    public float rangeCheckPlayer = 60;

    public RigidbodyFirstPersonController fpsPlayer;
    public float intervalToCheck = 0.2f;

    private void Start()
    {
        npc = GetComponent<NpcController>();
        playerRigidbody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody>();
        isPenaltyPlayer = false;        
    }

    public void UpdateStatusPenalty(bool valueBool)
    {
        isPenaltyPlayer = valueBool;
    }

    public void CheckPlayerSpeedStart()
    {
        StartCoroutine(CheckPlayerSpeed());
    }

    public void CheckPlayerSpeedStop()
    {
        StopAllCoroutines();
    }
    
    private IEnumerator CheckPlayerSpeed()
    {
        float dangerSpeedBorderPlayer = 6;
        while (true)
        {
            yield return new WaitForSeconds(intervalToCheck);

            distanceToPlayer = Vector3.Distance(transform.position, fpsPlayer.transform.position);
            if (!isPenaltyPlayer && distanceToPlayer <= rangeCheckPlayer &&
                playerRigidbody.velocity.magnitude > dangerSpeedBorderPlayer)
            {
                npc.TransitionToState(npc.stalkingState);
                print("IEnumerator CheckPlayerSpeed()");
                break;
            }
        }
    }

}
