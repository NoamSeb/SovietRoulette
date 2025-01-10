using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerQuiz : MonoBehaviour
{
    [Header ("Data de questions")]
    [SerializeField] Quiz quiz_questions;

    [Header("Numéro joueur")]
    [SerializeField] TextMeshProUGUI namePlayer;

    [Header("Gestion affichage des questions et réponses")]
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answerA;
    [SerializeField] TextMeshProUGUI answerB;

    [Header("Boutton des réponses")]
    [SerializeField] Button buttonA;
    [SerializeField] Button buttonB;

    [Header("Affichage réponse vrai ou faux")]
    [SerializeField] GameObject imgRep;
    [SerializeField] GameObject panelVrai;
    [SerializeField] GameObject panelFaux;

    [Header("Gestion audio pour mauvaise réponse")]
    [SerializeField] List<AudioClip> audios;

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
        imgRep.SetActive(true);
        panelVrai.SetActive(true);
        panelFaux.SetActive(false);
    }

    void _Action2()
    {
        Debug.Log("Faux");
        imgRep.SetActive(true);
        panelFaux.SetActive(true);
        panelVrai.SetActive(false);
    }

    private void Start()
    {
        imgRep.SetActive(false);
        _AffichageQuestion();
    }
}
