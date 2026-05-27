using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable currentInteractable;
    public GameObject interactHint;

    private void Update()
    {
        // ✅ Đổi eKey → bKey
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            if (currentInteractable != null)
            {
                currentInteractable.inInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            if (interactHint != null)
                interactHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            if (interactHint != null)
                interactHint.SetActive(false);
        }
    }
}