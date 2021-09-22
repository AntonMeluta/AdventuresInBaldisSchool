using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSceneMoving : MonoBehaviour
{
    Vector3 direction;
    Rigidbody rb;

    public Transform player;
    public Transform targetVelocity;
    public float speedMoving = 160;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        transform.rotation = player.rotation;
        transform.position = player.position + Vector3.up / 2;

        direction = (targetVelocity.position - transform.position).normalized;

        EventsBroker.EventRestartGame += ForRestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= ForRestartGame;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter снежинки!!!");
        if (collision.gameObject.GetComponent<NpcController>())
        {
            collision.gameObject.GetComponent<NpcController>().IceDamage();
        }

        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        //transform.Translate(direction * Time.deltaTime * 2, Space.World);
        rb.velocity = direction * Time.deltaTime * speedMoving;
    }

    private void ForRestartGame()
    {
        gameObject.SetActive(false);
    }
}
