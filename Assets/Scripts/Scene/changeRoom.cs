using UnityEngine;
using UnityEngine.SceneManagement;

public class changeRoom : MonoBehaviour
{
    public string senceToLoad;

    // Dùng cho BUTTON (click)
    public void ChangeSceneShow()
    {
        SceneManager.LoadScene(senceToLoad);
    }

    // Dùng cho TRIGGER (chạm vào)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(senceToLoad);
        }
    }
}