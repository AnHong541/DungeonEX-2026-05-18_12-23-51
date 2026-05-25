using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tắt collider núi
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = false;
            }

            // Bật collider boundary
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = true;
            }

            // Đổi sorting order của player
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }
}