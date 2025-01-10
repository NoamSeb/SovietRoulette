using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    [Header("Sons")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip reloadClip;
    [SerializeField] AudioClip SIGMABOY;
    [SerializeField] AudioClip LOFI_background;

    [Header("Gestion du barillet")]
    public GameObject[] PistolArray ;
    [SerializeField] GameObject Bullet;

    [Header("GameData pour stocker le nbr de joueur")]
    [SerializeField] GameData gameData;

    [Header("Canvas et Text")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Canvas canvas;
    [SerializeField] List<Sprite> imageList;
    private Image canvasImage;
    [SerializeField] Canvas fin_du_jeu;
    [SerializeField] TextMeshProUGUI textWinner;

    [Header("Animator")]
    [SerializeField] Animator barilletAnim;

    private Dictionary<int, bool> nbrPlayers = new Dictionary<int, bool>();
    private int alives;
    int winner;
    public int currentPlayerIndex;

    private bool isFinished = false;


    public event Action Win;
     private int listIndex;

    [SerializeField] GameObject managerQuiz;
    public bool isShoot = false;

    void Start()
    {
        AudioManager.instance.musicSource.clip = LOFI_background;
        AudioManager.instance.musicSource.Play();
        PrepareDictionnary();
        ResetBullet();
        currentPlayerIndex = 1;
        fin_du_jeu.enabled = false;
        canvas.enabled= false;
        canvasImage= canvas.GetComponentInChildren<Image>();
        Win += () => StartCoroutine(Winner());
        alives = nbrPlayers.Count;
        isShoot = false;

    }

   
    void Update()
    {
        
        if(alives > 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                if (canvas.isActiveAndEnabled)
                {
                    canvas.enabled = false;
                }
                else
                {
                    ChangeSlot();
                }

            }
        }
        else
        {
            if(isFinished && Input.GetButtonDown("Fire1"))
            {


               //ajouter transition vers la fin

            }
        }


        if (isShoot && Input.GetMouseButtonDown(0))
        {
            managerQuiz.GetComponent<ManagerQuiz>()._AffichageQuestion();
        }


        //if (AllDeath())
        //{
        //    Destroy(gameObject);
        //}

    }

   public void ResetBullet()
    {
        ClearAllBulletInPistol();
        listIndex = 0;
        //currentPlayerIndex = 1;
        int bullet_index= UnityEngine.Random.Range(0, PistolArray.Length-1);
        PistolArray[bullet_index] = Bullet;
    }

    void ClearAllBulletInPistol()
    {
        for (int i = 0; i < PistolArray.Length; i++)
        {
            PistolArray[i] = null;
        }
    }

    //public void ResetBulletAndShoot()
    //{
    //    ResetBullet();
    //    StartCoroutine(Shoot());
    //}



    void ChangeSlot()
    {
        barilletAnim.SetTrigger("GO");
        StartCoroutine(Shoot());
    }

    void PrepareDictionnary()
    {
        for (int i = 1; i < gameData.PlayerNumber+1; i++)
        {
            nbrPlayers.Add(i,true);
           
        }
        // Afficher uniquement les clés
        foreach (var key in nbrPlayers.Keys)
        {
            Debug.Log($"Clé : {key}");
        }
        //for (int i = 1; i < gameData.PlayerNumber + 1; i++)
        //{
        //    currentPlayers.Add(i);
        //}

    }

    void Death(int index)
    {
       
        if (index > gameData.PlayerNumber)
        {
            currentPlayerIndex = 1;
            index = currentPlayerIndex;
        }
        if (nbrPlayers[index] == true)
        {
            nbrPlayers[index] = false;

            text.text = $"Le joueur {index} a perdu :))";
            Debug.Log(nbrPlayers[index] + index.ToString());
            ResetBullet();
            return;

        }
      
      Death(index +1);
            
        
    }

    //bool AllDeath()
    //{
        
    //    foreach (var key in nbrPlayers.Keys)
    //    {
    //        if (nbrPlayers[key] == true)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    
    IEnumerator Winner()
    {
        isFinished = true;
        yield return new WaitForSeconds(1f);
        foreach(var key in nbrPlayers.Keys)
        {
            if(nbrPlayers[key] == true)
            {
                winner = key;
            }
        }
        canvas.enabled = false;
        fin_du_jeu.enabled = true;
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = SIGMABOY;
        AudioManager.instance.musicSource.Play();
        textWinner.text = $"Le joueur {winner} a gagné !!";

    }

    void NextStep()
    {
        if (currentPlayerIndex >= gameData.PlayerNumber)
        {
            currentPlayerIndex = 1;
        }
        else
        {
            currentPlayerIndex++;
        }
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        if (PistolArray[listIndex] != null)
        {
            AudioManager.instance.SFXSource.PlayOneShot(shootClip);
            PistolArray[listIndex] = null;
            ChangeImageInCanvas();
            yield return new WaitForSeconds(0.5f);
            canvas.enabled = true;
            Death(currentPlayerIndex);
            alives--;
            if(alives == 1)
            {
                Win.Invoke();
            }
            else
            {
                isShoot = true;
            }

        }

        else
        {
            listIndex++;
            AudioManager.instance.SFXSource.PlayOneShot(reloadClip);
            //Debug.Log("Changement de slot");
            isShoot = true;
        }

        NextStep();
        
    }

    void ChangeImageInCanvas()
    {
        canvasImage.sprite = imageList[(UnityEngine.Random.Range(0, (imageList.Count)))];
    }
}
