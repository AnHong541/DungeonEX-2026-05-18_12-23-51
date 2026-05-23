using UnityEngine;

[CreateAssetMenu(fileName = "NewQuesion", menuName = "message")]
public class QuesionData : ScriptableObject
{
    public string tenQuest;
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
}