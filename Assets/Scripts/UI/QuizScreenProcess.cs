using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScreenProcess : MonoBehaviour
{
    GirlInteaction girlInteaction;
    bool isGirlQuiz;

    int indexTask;
    int firstVariable;
    int secondVariable;
    int correctAnswer;
    int indexCorrectAnswer;
    bool isAdditionalOperation;

    public Text textQuestion;
    public Button[] answerButtons;
    public Button ExtraPushButton;
    public Slider sliderDifficulty;

    public float boostSpeedValueBaldis = 1.5f;

    private void Awake()
    {
        girlInteaction = FindObjectOfType<GirlInteaction>();
        ExtraPushButton.onClick.AddListener(PushGirlAction);
    }

    private void OnEnable()
    {
        isGirlQuiz = girlInteaction.isInGirlQuiz;
        ExtraPushButton.gameObject.SetActive(isGirlQuiz);

        indexTask = 0;        
        NewTask();
    }
    
    //������������ ����������, ���� ��������� � ���������� �����
    private void NewTask()
    {
        ClearListenerButtons();

        int boderValue = StatsManager.�omplexityGame;
        int multiply = 10;
        firstVariable = Random.Range(-boderValue * multiply, boderValue * multiply);
        secondVariable = Random.Range(-boderValue * multiply, boderValue * multiply);

        isAdditionalOperation = 0 == Random.Range(0, 2);
        if (isAdditionalOperation)
        {
            textQuestion.text = firstVariable + " + " + secondVariable;
            correctAnswer = firstVariable + secondVariable;
        }
        else
        {
            textQuestion.text = firstVariable + " - " + secondVariable;
            correctAnswer = firstVariable - secondVariable;
        }

        indexCorrectAnswer = Random.Range(0, answerButtons.Length);
        answerButtons[indexCorrectAnswer].GetComponentInChildren<Text>().text =
            correctAnswer.ToString();
        answerButtons[indexCorrectAnswer].onClick.AddListener(TapCorectAnswer);

        //������������� 3 ������������ ������                 
        GenerateRandomAnswers(correctAnswer, indexCorrectAnswer);
    }
    
    private void GenerateRandomAnswers(int correctAnswer, int indexCorrectAnswer)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i == indexCorrectAnswer)           
                continue;

            int incorectNumber = Random.Range(5, 50);
            if (0 == Random.Range(0, 2))            
                incorectNumber = incorectNumber + correctAnswer;
            else
                incorectNumber = incorectNumber - correctAnswer;

            answerButtons[i].GetComponentInChildren<Text>().text = incorectNumber.ToString();
            answerButtons[i].onClick.AddListener(TapIncorectAnswer);
        }
    }

    //������� ��� ���������� ������
    private void TapCorectAnswer()
    {
        indexTask++;
        if (indexTask < answerButtons.Length - 1)
            NewTask();
        else
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.game);
            gameObject.SetActive(false);

            if (!isGirlQuiz)
                FindObjectOfType<NotebooksControl>().PlayerPickupNotebook();
            else
                girlInteaction.RepeatPatrolMoving();

            EventsBroker.RestartHuntingForPlayer();
        }            
    }

    //������� ��� ������������ ������
    private void TapIncorectAnswer()
    {
        indexTask++;
        if (indexTask < answerButtons.Length - 1)
        {
            FindObjectOfType<BaldisSpeedHelper>().IncreaseSpeedAgent(boostSpeedValueBaldis);
            NewTask();
        }            
        else
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.game);
            gameObject.SetActive(false);

            if (!isGirlQuiz)
                FindObjectOfType<NotebooksControl>().PlayerPickupNotebook();
            else
                girlInteaction.RepeatPatrolMoving();

            EventsBroker.RestartHuntingForPlayer();
        }
    }

    //�������: ���������� �������
    private void PushGirlAction()
    {
        EventsBroker.RestartHuntingForPlayer();
        NpcController bully = FindObjectOfType<BullyInteraction>().GetComponent<NpcController>();
        bully.TransitionToState(bully.stalkingState);
        girlInteaction.RepeatPatrolMoving();        
        gameObject.SetActive(false);
    }

    private void ClearListenerButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();
        }            
    }
}
