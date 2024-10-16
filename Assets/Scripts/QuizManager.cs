using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public List<Question> questions = new List<Question>();
    public Text questionText;
    public Button[] answerButtons;
    public Button nextActionButton;
    private int currentQuestionIndex = 0;

    public Image IbisImageObject;
    public Sprite IbisIdle;
    public Sprite IbisCorrect;
    public Sprite IbisWrong;

    private void Start()
    {
        nextActionButton.gameObject.SetActive(false);
        ShowQuestion();
    }

    public void ShowQuestion()
    {
        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];
            IbisImageObject.sprite = IbisIdle;
            answerButtons[i].image.color = Color.white;
            answerButtons[i].interactable = true;
        }
    }

    public void AnswerButtonPressed(int index)
    {
        foreach (Button button in answerButtons)
        {
            button.interactable = false;
        }

        Question currentQuestion = questions[currentQuestionIndex];

        if (index == currentQuestion.correctAnswerIndex)
        {
            SoundManager.PlaySound(SoundType.GAMECORRECT);
            IbisImageObject.sprite = IbisCorrect;
            answerButtons[index].image.color = Color.green;
            Invoke("NextQuestion", 1f);
        }
        else
        {
            SoundManager.PlaySound(SoundType.GAMEWRONG);
            IbisImageObject.sprite = IbisWrong;
            answerButtons[index].image.color = Color.red;
            Invoke("ResetButtonColor", 1f);
        }
    }

    private void ResetButtonColor()
    {
        foreach (Button button in answerButtons)
        {
            IbisImageObject.sprite = IbisIdle;
            button.image.color = Color.white;
            button.interactable = true;
        }

        ShowQuestion();
    }

    private void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            nextActionButton.gameObject.SetActive(true);
        }
    }
}
