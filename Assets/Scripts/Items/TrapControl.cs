using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrapControl : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider boxCollider;
    private AudioController audioController;

    private Transform player;

    public Sprite openedSprite;
    public Sprite closedSprite;

    [Inject]
    private void ConstructorLike(PlayerController playerController)
    {
        player = playerController.transform;
    }

    [Inject]
    private void ConstructorLike(AudioController audio)
    {
        audioController = audio;
    }

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

        audioController.PlaySoundEffect(SoundEffect.TrapInstall);
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

            Invoke("ForRestartGame", npc.DelayTrapDamage);
        }
    }

    private void ForRestartGame()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

}
