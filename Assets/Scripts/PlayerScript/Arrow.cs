using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction = Vector2.right;
    public float lifeSpawn = 2;
    public float speed;

    public LayerMask enemyLayer;
    public LayerMask obstacleLayer;

    public SpriteRenderer sr;

    public int Damage;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    void Start()
    {
        rb.linearVelocity = direction * speed;
        RotateArrow();
        Destroy(gameObject, lifeSpawn);
    }

    private void RotateArrow()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<EnemyHealth>().ChangeHealth(-Damage);
            collision.gameObject.GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce, knockbackTime, stunTime);
            Destroy(gameObject);
        }
        else if ((obstacleLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            AttachToTarget(collision.gameObject.transform);
        }
    }

    private void AttachToTarget(Transform target)
    {
        rb.linearVelocity = Vector2.zero;
        rb.useFullKinematicContacts = true;
    }
}