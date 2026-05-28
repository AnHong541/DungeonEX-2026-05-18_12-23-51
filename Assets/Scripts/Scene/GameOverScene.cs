using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{

    public string sceneToDead;
    public Animator animator;
    private bool isDeadTriggered = false;

    void Update()
    {
        if (StatManager.Instance != null && StatManager.Instance.CurrentHealth <= 0)
        {
            if (!isDeadTriggered) {
                TriggerGameOver();
            }

        }
    }
    private void TriggerGameOver()
    {
        isDeadTriggered = true;


        if (animator != null)
        {

            animator.SetTrigger("Deadnimator");
        }

    }
    private void LoadDeadScene()
    {
        if (!string.IsNullOrEmpty(sceneToDead))
        {
            SceneManager.LoadScene(sceneToDead);
        }
    }
}

