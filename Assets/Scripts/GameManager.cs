using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameOver & Menu Settings")]
    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private string currentSceneName;   
    [SerializeField] private string menuSceneName;     

    int maxPlatfrom = 0;
   public static GameManager instance;
   public GameOverScene gameOverScene;
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
    public void ShowGameOverScreen()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        StatManager.Instance.ResetStats();
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    public void GoToMainMenu()
    {
       
        CleanUpAndDestroy();
        SceneManager.LoadScene(menuSceneName);
    }

}