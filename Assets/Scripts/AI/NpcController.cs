using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    private Transform playerPosition;

    public TypeAI typeAi;

    //Patrolling
    private NavMeshAgent agent;
    int currentPointPatrolling;
    public Transform[] targets;
    public int minBorderInterval = 10;
    public int maxBorderInterval = 25;

    //State NPC
    private NpcBaseState currentState;
    public Sprite goodFace;
    public Sprite evilFace;
    public readonly NpcBaseState idleState = new IdleState();
    public readonly NpcBaseState patrolState = new PatrolState();
    public readonly NpcBaseState stalkingState = new StalkingState();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().transform;

        TransitionToState(idleState);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void TransitionToState(NpcBaseState state)
    {
        if (currentState == state)
            return;

        StopAllCoroutines();
        currentState = state;
        currentState.EnterState(this);
    }

    public void SetExpression(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    
    public void ToPointSpecial(Transform pointEvacuation)
    {
        agent.SetDestination(pointEvacuation.position);
    }

    public void StopMoving()
    {
        agent.SetDestination(transform.position);
    }

    public void StartStalking()
    {
        StartCoroutine(StalkingPlayerEnumerator());
    }

    //Преследование игрока
    private IEnumerator StalkingPlayerEnumerator()
    {
        //NeedFix убрать комментарии в коррутине
        while (true)
        {
            agent.destination = playerPosition.position;
            yield return null;
        }
        /*float dist = Vector3.Distance(transform.position, playerPosition.position);
        float distToInteraction = 1.5f;

        do
        {            
            agent.destination = playerPosition.position;
            yield return null;

            dist = Vector3.Distance(transform.position, playerPosition.position);
        } while (dist > distToInteraction);*/

        //Переход в PlayerInteraction state NeedFix! (ВЕРНУТЬ ЕСЛИ CollisionEnter БУДЕТ УБРАН В NPC)
        TransitionToState(idleState);
    }

    public void StartPatrolling()
    {
        StartCoroutine(GoToNextPoint());
    }

    //Патрулирование школы
    private IEnumerator GoToNextPoint()
    {        
        int randTaret = 0;
        while (true)
        {
            while (randTaret == currentPointPatrolling)
                randTaret = Random.Range(0, targets.Length);
            currentPointPatrolling = randTaret;
            agent.destination = targets[currentPointPatrolling].position;
            yield return new WaitForSeconds(Random.Range(minBorderInterval, maxBorderInterval));
        }
    }
}
