using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion quaternion;    

    private SpriteRenderer spriteRenderer;
    private Transform playerPosition;
    private Vector3 forLookAt;

    public readonly string layerDefault = "AI";
    public readonly string layerNotCollisionPlayer = "AIExtra";

    public TypeAI typeAi;

    //Patrolling
    private NavMeshAgent agent;
    int currentPointPatrolling;
    public Transform[] targets;
    public int minBorderInterval = 10;
    public int maxBorderInterval = 25;

    //State NPC
    public GameObject danceCicrle;
    public Transform targetDance;
    List<NpcBaseState> listPrevStates;
    private NpcBaseState prevState;
    public NpcBaseState currentState;//свойствa
    public int delayTrapDamage = 10;
    public int periodPanic = 30;
    public int periodLesson = 40;
    public int periodDance = 50;
    public Sprite goodFace;
    public Sprite evilFace;
    public readonly NpcBaseState idleState = new IdleState();
    public readonly NpcBaseState patrolState = new PatrolState();
    public readonly NpcBaseState stalkingState = new StalkingState();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        listPrevStates = new List<NpcBaseState>();
        prevState = null;
        startPosition = transform.position;
        quaternion = transform.rotation;
    }

    private void OnEnable()
    {
        EventsBroker.EventRestartGame += RestartPositionNpc;
        EventsBroker.HuntingForPlayerStopEvent += CancelledHuntingForPlayer;
    }

    private void OnDisable()
    {
        EventsBroker.EventRestartGame -= RestartPositionNpc;
        EventsBroker.HuntingForPlayerStopEvent -= CancelledHuntingForPlayer;
    }

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().transform;

        switch (typeAi)
        {
            case TypeAI.Baldis:
                TransitionToState(idleState);
                break;
            case TypeAI.Principal:
                TransitionToState(patrolState);
                break;
            case TypeAI.Bully:
                TransitionToState(patrolState);
                break;
            case TypeAI.Girl:
                TransitionToState(patrolState);
                break;
            case TypeAI.Rider:
                TransitionToState(patrolState);
                break;
            default:
                break;
        }
    }

    private void CancelledHuntingForPlayer()
    {
        switch (typeAi)
        {
            case TypeAI.Baldis:
                break;
            case TypeAI.Principal:
                if (currentState == stalkingState)
                {
                    TransitionToState(idleState);
                    EventsBroker.HuntingForPlayerRestart += ResumeStalkingPlayer;
                }                
                break;
            case TypeAI.Bully:
                if (currentState == stalkingState)
                {
                    TransitionToState(idleState);
                    EventsBroker.HuntingForPlayerRestart += ResumeStalkingPlayer;
                }
                break;
            case TypeAI.Girl:
                break;
            case TypeAI.Rider:
                break;
            default:
                break;
        }
    }

    private void RestartPositionNpc()
    {
        CancelInvoke();
        listPrevStates.Clear();
        prevState = null;
        danceCicrle.SetActive(false);
        agent.enabled = false;
        transform.position = startPosition;
        transform.rotation = quaternion;
        agent.enabled = true;

        switch (typeAi)
        {
            case TypeAI.Baldis:
                TransitionToState(idleState);
                break;
            case TypeAI.Principal:
                TransitionToState(patrolState);
                break;
            case TypeAI.Bully:
                TransitionToState(patrolState);
                break;
            case TypeAI.Girl:
                TransitionToState(patrolState);
                break;
            case TypeAI.Rider:
                TransitionToState(patrolState);
                break;
            default:
                break;
        }
        
    }
    
    private void Update()
    {
        currentState.Update(this);
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(playerPosition);
        forLookAt = transform.eulerAngles;
        forLookAt.x = 0;
        transform.eulerAngles = forLookAt;
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
    
    public void IceDamage()
    {
        SaveCurentState();
        TransitionToState(idleState);
        Invoke("ReturnToPrevState", delayTrapDamage);
    }

    //Реакция на событие возобновления преследования игрока
    private void ResumeStalkingPlayer()
    {
        TransitionToState(stalkingState);
        EventsBroker.HuntingForPlayerRestart -= ResumeStalkingPlayer;
    }

    private void FixedUpdate()
    {
        if (prevState != null)
            print("PREV STATE = " + prevState.ToString());
    }

    //Сохранить состояние для возвращения к нему (по необходимости)
    public void SaveCurentState()
    {
            prevState = currentState;
            listPrevStates.Add(prevState);
    }

    //Вернуться к предыдущему состоянию (после заморзки, файр паники, дискотеки или урока)
    public void ReturnToPrevState()
    {
        prevState = listPrevStates[listPrevStates.Count - 1];
        TransitionToState(prevState);
        listPrevStates.Remove(prevState);
    }

    public void SetExpression(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    #region Moving working
    public void ToPointSpecial(Transform pointEvacuation)
    {
        agent.SetDestination(pointEvacuation.position);
    }

    public void DancingNpc()
    {
        danceCicrle.SetActive(true);
        StartCoroutine(DancingEnumerator());
    }

    public void StopMoving()
    {
        agent.SetDestination(transform.position);
    }

    public void StartStalking()
    {
        StartCoroutine(StalkingPlayerEnumerator());
    }

    //Танец непися
    private IEnumerator DancingEnumerator()
    {
        while (true)
        {
            agent.destination = targetDance.position;
            yield return null;
        }
    }

    //Преследование игрока
    private IEnumerator StalkingPlayerEnumerator()
    {
        while (true)
        {
            agent.destination = playerPosition.position;
            yield return null;
        }        
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
    #endregion

    #region Layers working
    public void SetLayerDefault()
    {
        gameObject.layer = LayerMask.NameToLayer(layerDefault);
    }

    public void SetLayerNotCOllisionPlayer()
    {
        gameObject.layer = LayerMask.NameToLayer(layerNotCollisionPlayer);
    }
    #endregion
}

public enum TypeAI
{
    Baldis,
    Principal,
    Bully,
    Girl,
    Rider
}
