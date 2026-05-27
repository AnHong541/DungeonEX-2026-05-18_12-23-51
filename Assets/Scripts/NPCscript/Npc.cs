using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour, IInteractable
{
    public static bool IsDialogueActive { get; private set; }

    public QuesionData quesionData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image portraitImage;
    public Button closeButton; 

    private int dialogueIndex;
    private bool isTyping;

    private void Start()
    {
        // ✅ Tự động gắn function cho nút X khi game chạy
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(EndDialogue);
        }
    }

    private void Update()
    {
        if (IsDialogueActive && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    public bool CanInteract() => true;

    public void inInteract()
    {
        if (quesionData == null) return;
        if (!IsDialogueActive && PauseController.IsGamePaused) return;

        if (IsDialogueActive)
            NextLine();
        else
            StartDialogue();
    }

    private void StartDialogue()
    {
        IsDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(quesionData.npcName);

        if (portraitImage != null && quesionData.npcPortrait != null)
            portraitImage.sprite = quesionData.npcPortrait;

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
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in quesionData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(quesionData.typingSpeed);
        }

        isTyping = false;
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        IsDialogueActive = false;
        isTyping = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false);
    }
}