using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    Rigidbody rb;
    SpriteRenderer spriteRenderer;
    BoxCollider boxCollider;

    public Transform player;

    public Sprite openedSprite;
    public Sprite closedSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        spriteRenderer.sprite = openedSprite;
        boxCollider.enabled = true;
        rb.isKinematic = false;

        transform.rotation = player.rotation;
        transform.position = player.position + Vector3.up + player.transform.forward;

        EventsBroker.EventRestartGame += ForRestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= ForRestartGame;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NpcController>())
        {
            NpcController npc = collision.gameObject.GetComponent<NpcController>();
            npc.IceDamage();

            spriteRenderer.sprite = closedSprite;
            boxCollider.enabled = false;
            rb.isKinematic = true;

            Invoke("ForRestartGame", npc.delayTrapDamage);
        }
    }

    private void ForRestartGame()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

}
