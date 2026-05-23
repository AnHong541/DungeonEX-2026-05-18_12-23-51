using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public QuesionData quesionData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image portraitImage; // Sửa tên biến cho đúng

    private int dialogueIndex;
    private bool isTyping;        // Sửa int -> bool
    private bool isDialogueActive; // Sửa int -> bool

    public bool CanInteract()
    {
        return true; // Luôn cho phép interact để NextLine() hoạt động
    }

    public void inInteract()
    {
        if (quesionData == null) return;

        // Sửa tên class PauseController cho đúng
        if (PauseController.IsGamePaused && !isDialogueActive) return;

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    // Tách ra ngoài, không lồng trong inInteract()
    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(quesionData.npcName);

        // Xóa dòng cũ, chỉ giữ lại đoạn có kiểm tra null
        if (portraitImage != null && quesionData.npcPortrait != null)
        {
            portraitImage.sprite = quesionData.npcPortrait;
        }
        else
        {
            Debug.Log("Portrait null: " +
                (portraitImage == null ? "portraitImage chưa gán!" : "npcPortrait chưa có sprite!"));
        }

        dialoguePanel.SetActive(true);
        PauseController.SetPause(true);
        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(quesionData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < quesionData.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else // Thêm else để EndDialogue chỉ chạy khi hết line
        {
            EndDialogue();
        }
    }

    // Tách TypeLine ra ngoài, đổi IEnumerable -> IEnumerator
    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in quesionData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(quesionData.typingSpeed); // Đổi ở đây
        }

        isTyping = false;
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        isTyping = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false); // Sửa PauseConTroller -> PauseController
    }
}