using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pistol : MonoBehaviour
{
    [SerializeField] private const int indexTotal = 10;
    public GameObject[] PistolArray = new GameObject[indexTotal];
    [SerializeField] GameObject Bullet;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip reloadClip;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Canvas canvas;
    

    [SerializeField] private int listIndex;
    void Start()
    {
        
        ResetBullet();
  
        canvas.enabled= false;
        Debug.Log(PistolArray.Length);
        
    }

   
    void Update()
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

   void ResetBullet()
    {
        listIndex = 0;
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
            text.text = $"{null} a perdu :))";
            ResetBullet();
        }
        else
        {
            listIndex++;
            audioSource.PlayOneShot(reloadClip);
            Debug.Log("Changement de slot");
        }
    }


}
