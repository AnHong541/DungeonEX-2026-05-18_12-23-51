using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable currentInteractable;
    public GameObject interactHint;

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("✅ Nhấn B thành công");

            if (currentInteractable != null)
            {
                Debug.Log("✅ Đang tương tác với: " + currentInteractable);
                currentInteractable.inInteract();
            }
            else
            {
                Debug.Log("❌ currentInteractable = NULL → Chưa vào vùng trigger NPC");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("🔵 Trigger Enter: " + other.name);

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            Debug.Log("✅ Gán currentInteractable = " + other.name);
            if (interactHint != null)
                interactHint.SetActive(true);
        }
        else
        {
            Debug.Log("⚠️ Object " + other.name + " không có IInteractable");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("🔴 Trigger Exit: " + other.name);
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            if (interactHint != null)
                interactHint.SetActive(false);
        }
    }
}