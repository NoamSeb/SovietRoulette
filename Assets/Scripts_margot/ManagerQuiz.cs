using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerQuiz : MonoBehaviour
{
    [SerializeField] Quiz quiz_questions;

    [SerializeField] TextMeshProUGUI namePlayer;
    
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answerA;
    [SerializeField] TextMeshProUGUI answerB;

    [SerializeField] Button buttonA;
    [SerializeField] Button buttonB;

    int nbRandom;

    void _AffichageQuestion()
    {
        nbRandom = UnityEngine.Random.Range(0,quiz_questions.questions.Count);

        question.text = quiz_questions.questions[nbRandom].question;

        answerA.text = quiz_questions.questions[nbRandom].answer_A.answer;
        answerB.text = quiz_questions.questions[nbRandom].answer_B.answer;

        UpdateButtonAnswer();
    }

    void UpdateButtonAnswer()
    {
        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();

        if (quiz_questions.questions[nbRandom].answer_A.isTrue)
        {
            buttonA.onClick.AddListener(_Action1);
        }
        else
        {
            buttonA.onClick.AddListener(_Action2);
        }

        if (quiz_questions.questions[nbRandom].answer_B.isTrue)
        {
            buttonB.onClick.AddListener(_Action1);
        }
        else
        {
            buttonB.onClick.AddListener(_Action2);
        }
    }

    void _Action1()
    {
        Debug.Log("Vrai");
    }

    void _Action2()
    {
        Debug.Log("Faux");
    }

    private void Start()
    {
        _AffichageQuestion();
    }
}
