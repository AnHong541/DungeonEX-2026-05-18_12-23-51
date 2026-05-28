using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeRoom : MonoBehaviour
{
    public string senceToLoad;
    public Animator fadeAnim;
    public float fadeTime = .5f;
    public Vector2 newPlayerPosition;
    private Transform player;

    private void Start()
    {
        // Tìm Player trong scene khi game bắt đầu
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy Player!");
        }
    }

    // Dùng cho BUTTON (click)
    public void ChangeSceneShow()
    {
        StartCoroutine(DelayFade());
    }

    // Dùng cho TRIGGER (chạm vào)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        fadeAnim.Play("fadeToWhite");
        yield return new WaitForSeconds(fadeTime);

        // Chỉ di chuyển player nếu tìm thấy
        if (player != null)
        {
            player.position = newPlayerPosition;
        }

        SceneManager.LoadScene(senceToLoad);
    }
}