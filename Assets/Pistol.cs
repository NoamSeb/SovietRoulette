using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private const int indexTotal = 10;
    public GameObject[] PistolArray = new GameObject[indexTotal];
    [SerializeField] GameObject Bullet;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootClip;

   [SerializeField] private int listIndex;
    void Start()
    {
        
        ResetBullet();
        listIndex = 0;
        Debug.Log(PistolArray.Length);
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeSlot();
            
        }
    }

   void ResetBullet()
    {
        int bullet_index= UnityEngine.Random.Range(0, PistolArray.Length-1);
        PistolArray[bullet_index] = Bullet;

    }



    void ChangeSlot()
    {
        
        if(PistolArray[listIndex] != null)
        {
            audioSource.PlayOneShot(shootClip);
            Destroy(gameObject);
        }
        else
        {
            listIndex++;
            Debug.Log("Changement de slot");
        }
    }


}
