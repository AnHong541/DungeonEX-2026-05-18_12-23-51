using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DungeonClearUI : MonoBehaviour
{
    [Header("Enemy chỉ định")]
    public GameObject targetEnemy;

    [Header("UI")]
    public CanvasGroup dungeonClearPanel;

    [Header("Buttons")]
    public Button playAgainButton;
    public Button mainMenuButton;

    [Header("Scenes")]
    public string playAgainSceneName;
    public string mainMenuSceneName;

    private void Start()
    {
        dungeonClearPanel.alpha = 0;
        dungeonClearPanel.interactable = false;
        dungeonClearPanel.blocksRaycasts = false;

        playAgainButton.onClick.AddListener(() => LoadScene(playAgainSceneName));
        mainMenuButton.onClick.AddListener(() => LoadScene(mainMenuSceneName));
    }

    private void Update()
    {
        if (targetEnemy == null && dungeonClearPanel.alpha == 0)
        {
            ShowDungeonClear();
        }
    }

    private void ShowDungeonClear()
    {
        dungeonClearPanel.alpha = 1;
        dungeonClearPanel.interactable = true;
        dungeonClearPanel.blocksRaycasts = true;
    }

    private void LoadScene(string sceneName)
    {
            SceneManager.LoadScene(sceneName);
    }
}