using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public List<GameObject> PistolList;
    [SerializeField] GameObject Bullet;

    [SerializeField] AudioClip shootClip;

   [SerializeField] private int listIndex;
    void Start()
    {
        ResetBullet();
        listIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeSlot();
            
        }
    }

   void ResetBullet()
    {
        int bullet_index= UnityEngine.Random.Range(0, PistolList.Count-1);
        PistolList[bullet_index] = Bullet;

    }



    void ChangeSlot()
    {
        
        if(PistolList[listIndex] != null)
        {
            Destroy(gameObject);
        }
        else
        {
            listIndex++;
            Debug.Log("Changement de slot");
        }
    }


}
