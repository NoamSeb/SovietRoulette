using Codice.Client.Common.GameUI;
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
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> audios;

    [Header("Gestion pistolet")]
    [SerializeField] GameObject managerPistolet;
    [SerializeField] GameObject canvaQuiz;

    int nbRandom;

    int indexRandomAudio;
    bool rep = false;

    public void _AffichageQuestion()
    {
        managerPistolet.SetActive(false);
        managerPistolet.GetComponentInChildren<Pistol>().isShoot = false;
        //namePlayer.text = "Joueur " + managerPistolet.GetComponentInChildren<Pistol>().currentPlayerIndex;
        int index = managerPistolet.GetComponentInChildren<Pistol>().currentfinalplayers;
        namePlayer.text = "Joueur " + managerPistolet.GetComponentInChildren<Pistol>().finalPlayers[index-1];
        canvaQuiz.SetActive(true);
        imgRep.SetActive(false);

        nbRandom = UnityEngine.Random.Range(0,quiz_questions.questions.Count);

        question.text = quiz_questions.questions[nbRandom].question;

        answerA.text = quiz_questions.questions[nbRandom].answer_A.answer;
        answerB.text = quiz_questions.questions[nbRandom].answer_B.answer;

        UpdateButtonAnswer();
        rep = false;
        managerPistolet.SetActive(false);
    }

    void UpdateButtonAnswer()
    {
        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();


        if (quiz_questions.questions[nbRandom].answer_A.isTrue)
        {
            buttonA.onClick.AddListener(_ActionVrai);
        }
        else
        {
            buttonA.onClick.AddListener(_ActionFaux);
        }

        if (quiz_questions.questions[nbRandom].answer_B.isTrue)
        {
            buttonB.onClick.AddListener(_ActionVrai);
        }
        else
        {
            buttonB.onClick.AddListener(_ActionFaux);
        }
    }

    void _ActionVrai()
    {
        Debug.Log("Vrai");
        rep = true;
        imgRep.SetActive(true);
        panelVrai.SetActive(true);
        panelFaux.SetActive(false);

        managerPistolet.GetComponentInChildren<Pistol>().ResetBullet();
    }

    void _ActionFaux()
    {
        rep = true;
        Debug.Log("Faux");
        imgRep.SetActive(true);
        panelFaux.SetActive(true);
        panelVrai.SetActive(false);

        indexRandomAudio = UnityEngine.Random.Range(0, audios.Count);
        audioSource.PlayOneShot(audios[indexRandomAudio]);
    }

    private void Start()
    {
        canvaQuiz.SetActive(true);
        managerPistolet.SetActive(false);
        rep = false;
        imgRep.SetActive(false);
        _AffichageQuestion();
    }

    private void Update()
    {
        if (rep && Input.GetMouseButtonDown(0))
        {
            managerPistolet.SetActive(true);
            canvaQuiz.SetActive(false);
        }
    }
}
