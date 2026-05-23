using UnityEngine;
using UnityEngine.SceneManagement;

public class changeRoom : MonoBehaviour
{
    public string senceToLoad;

    public void ChangeSceneShow()
    {
        SceneManager.LoadScene(senceToLoad);
    }
}
