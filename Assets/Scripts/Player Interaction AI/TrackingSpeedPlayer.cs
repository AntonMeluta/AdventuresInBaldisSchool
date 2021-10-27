using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrackingSpeedPlayer : MonoBehaviour
{
    float distanceToPlayer = 0;
    NpcController npc;
    Rigidbody playerRigidbody;
    bool isPenaltyPlayer;

    [SerializeField]float rangeCheckPlayer = 60;

    [SerializeField] float intervalToCheck = 0.2f;

    [Inject]
    private void ConstructorLike(PlayerController playerController)
    {
        playerRigidbody = playerController.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        npc = GetComponent<NpcController>();
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

            distanceToPlayer = Vector3.Distance(transform.position, playerRigidbody.transform.position);
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
