using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScreenProcess : MonoBehaviour
{
    NpcController npcGirl;

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
        ExtraPushButton.gameObject.SetActive(npcGirl.currentState == npcGirl.idleState);

        indexTask = 0;        
        NewTask();
    }

    private void OnDisable()
    {
        ClearListenerButtons();
    }

    //сформировать переменные, знак оператора и правильный ответ
    private void NewTask()
    {
        
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

        //сгенерировать 3 неправильных ответа                 
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

    //—ќбытие при правильном ответе
    private void TapCorectAnswer()
    {
        indexTask++;
        if (indexTask < answerButtons.Length)
            NewTask();
        else
        {
            print("NeedFix событие, дневник собран - итератор дневников");
            GameManager.Instance.UpdateGameState(GameManager.GameState.game);
            gameObject.SetActive(false);            
        }            
    }

    //—ќбытие при Ќ≈правильном ответе
    private void TapIncorectAnswer()
    {
        indexTask++;
        if (indexTask < answerButtons.Length)
        {
            FindObjectOfType<BaldisSpeedHelper>().IncreaseSpeedAgent(boostSpeedValueBaldis);
            NewTask();
        }            
        else
        {
            print("NeedFix событие, дневник собран - итератор дневников");
            GameManager.Instance.UpdateGameState(GameManager.GameState.game);
            gameObject.SetActive(false);
        }
    }

    //—обытие: оттолкнуть девочку
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
