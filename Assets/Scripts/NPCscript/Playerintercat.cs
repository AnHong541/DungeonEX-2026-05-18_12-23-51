using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable currentInteractable;
    public GameObject interactHint;

    private int npcLayer;

    private void Start()
    {
        npcLayer = LayerMask.NameToLayer("NPC");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (currentInteractable != null)
                currentInteractable.inInteract();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != npcLayer) return;
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
        if (other.gameObject.layer != npcLayer) return;
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            if (interactHint != null)
                interactHint.SetActive(false);
        }
    }
}