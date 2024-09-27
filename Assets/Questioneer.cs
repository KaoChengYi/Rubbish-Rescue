using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Questioneer : MonoBehaviour, IInteractable
{
    [SerializeField] string[] question; // List of Questions
    int questionIndex = 0; // Question Index
    [SerializeField] string[] firstAnswers; // List of answer for each Question
    [SerializeField] string[] secondAnswers; // List of answer for each Question
    [SerializeField] string[] thirdAnswers; // List of answer for each Question
    [SerializeField] int[] correctAnswerNum; // 
    int selectedAnswerNum; // 

    [Header("References")]
    [SerializeField] GameObject QuestionUIGO;
    [SerializeField] TMP_Text questionTextUI;
    [SerializeField] TMP_Text[] answerTextsUI;
    [SerializeField] Button nextButton;

    [Header("Player References")]
    [SerializeField] FirstPersonLook fpLooks;
    [SerializeField] FirstPersonMovement fpMove;


    private void Start()
    {
        nextButton.interactable = false;
    }

    public void Interact()
    {
        QuestionUIGO.SetActive(true);
        ShowQuestion(questionIndex);
    }

    public void OnSubmitAnswer() // Button
    {
        if (selectedAnswerNum == correctAnswerNum[questionIndex])
        {
            nextButton.interactable = true;
            answerTextsUI[selectedAnswerNum].color = Color.green;

        } else
        {
            answerTextsUI[selectedAnswerNum].color = Color.red;

        }



        GoToNextQuestion();
        // Check if answer is correct
        // Go to next question if it's correct
    }



    void ShowQuestion(int questionNum)
    {
        questionTextUI.text = question[0];

        string[] currentAnswerIndex = GetAnswerArray(questionNum);

        string[] GetAnswerArray(int _curQuestionNum)
        {
            switch (_curQuestionNum)
            {
                case 0:
                    return firstAnswers;
                case 1:
                    return secondAnswers;
                case 2:
                    return thirdAnswers;
                default:
                    Debug.Log("Failed to find the current Answer Array");
                    return null;
            }
        }

        for (int i = 0; i < correctAnswerNum.Length; i++)
        {
            answerTextsUI[i].text = currentAnswerIndex[i];
        }



    }

    public void OnSelectAnswer(int _answerNum) // The answer button the player selected
    {
        selectedAnswerNum = _answerNum;
    }

    private void GoToNextQuestion() // Function for going to the next question
    {
        nextButton.interactable = false;
    }

    void Leave()
    {
        fpLooks.enabled = true;
        fpMove.enabled = true;
    }
}
