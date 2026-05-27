using UnityEngine;

public class Elevation_Exit : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders; // ← thêm vào

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Bật lại collider núi
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = true;
            }

            // Tắt boundary khi thoát ra
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = false; // ← tắt đi
            }

            // Trả sorting order về mặc định
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9    ;
        }
    }
}