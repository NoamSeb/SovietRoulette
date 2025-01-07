using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pistol : MonoBehaviour
{
    public GameObject[] PistolArray ;
    [SerializeField] GameObject Bullet;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip reloadClip;
    [SerializeField] AudioClip SIGMABOY;
    [SerializeField] GameData gameData;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Canvas canvas;
    [SerializeField] Canvas fin_du_jeu;
    [SerializeField] TextMeshProUGUI textWinner;

    private Dictionary<int, bool> nbrPlayers = new Dictionary<int, bool>();
    public int alives;
    int winner;
    public int currentPlayerIndex;
    
    [SerializeField] private int listIndex;
    void Start()
    {
        PrepareDictionnary();
        ResetBullet();
        currentPlayerIndex = 1;
        fin_du_jeu.enabled = false;
        canvas.enabled= false;
        
        alives = nbrPlayers.Count;
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
            if (Input.GetButtonDown("Fire1"))
            {
                

                    Winner();
                
            }
              
        }
        

        //if (AllDeath())
        //{
        //    Destroy(gameObject);
        //}

        
        
    }

   void ResetBullet()
    {
        listIndex = 0;
        //currentPlayerIndex = 1;
        int bullet_index= UnityEngine.Random.Range(0, PistolArray.Length-1);
        PistolArray[bullet_index] = Bullet;

    }



    void ChangeSlot()
    {
        
        if(PistolArray[listIndex] != null)
        {
            audioSource.PlayOneShot(shootClip);
            PistolArray[listIndex] = null;
            canvas.enabled = true;
            Death(currentPlayerIndex);
            alives--;

        }

        else
        {
            listIndex++;
            if (currentPlayerIndex >= gameData.PlayerNumber)
            {
                currentPlayerIndex = 1;
            }
            else
            {
                currentPlayerIndex++;
            }
            audioSource.PlayOneShot(reloadClip);
            //Debug.Log("Changement de slot");
        }
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
      
      
            
        
    }

    bool AllDeath()
    {
        
        foreach (var key in nbrPlayers.Keys)
        {
            if (nbrPlayers[key] == true)
            {
                return false;
            }
        }
        return true;
    }

    
    void Winner()
    {
        
        foreach(var key in nbrPlayers.Keys)
        {
            if(nbrPlayers[key] == true)
            {
                winner = key;
            }
        }
        fin_du_jeu.enabled = true;
        audioSource.PlayOneShot(SIGMABOY);
        textWinner.text = $"Le joueur {winner} a gagné !! :))";

    }

}
