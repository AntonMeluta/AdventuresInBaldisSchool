using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScreenProcess : MonoBehaviour
{
    NpcController npcGirl;
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

    public float boostSpeedValueBaldis = 1.5f;

    private void Awake()
    {
        npcGirl = GameObject.FindObjectOfType<GirlInteaction>().GetComponent<NpcController>();
        ExtraPushButton.onClick.AddListener(PushGirlAction);
    }

    private void OnEnable()
    {
        isGirlQuiz = npcGirl.currentState == npcGirl.idleState;
        ExtraPushButton.gameObject.SetActive(isGirlQuiz);

        indexTask = 0;        
        NewTask();
    }
    
    //������������ ����������, ���� ��������� � ���������� �����
    private void NewTask()
    {
        ClearListenerButtons();

        firstVariable = Random.Range(-10, 10);
        secondVariable = Random.Range(-10, 10);

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

            if (isGirlQuiz)
                FindObjectOfType<NotebooksControl>().PlayerPickupNotebook();
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

            if (isGirlQuiz)
                FindObjectOfType<NotebooksControl>().PlayerPickupNotebook();
        }
    }

    //�������: ���������� �������
    private void PushGirlAction()
    {
        NpcController bully = FindObjectOfType<BullyInteraction>().GetComponent<NpcController>();
        bully.TransitionToState(bully.stalkingState);
        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
        gameObject.SetActive(false);
    }

    private void ClearListenerButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();
            print("ClearListenerButtons() = " + i);
        }            
    }
}
