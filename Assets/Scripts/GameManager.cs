using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    [Header("Persistent Data")]
    public GameObject[] persistentObject;
 

   private void Awake()
   {
       if (instance != null)
       {
            CleanUpAndDestroy();
           return;
        }
       else
       {
           instance = this;
           DontDestroyOnLoad(gameObject);
           MarkPersistentObject();
       }
   }

    private void MarkPersistentObject()
    {
         foreach (GameObject obj in persistentObject)
         {
              if(obj != null)
              {
                   DontDestroyOnLoad(obj);
              }
         }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistentObject)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}