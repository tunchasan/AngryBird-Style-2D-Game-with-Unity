using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird hittedBird = collision.collider.GetComponent<Bird>();

        // Bird hits current enemy
        if (hittedBird != null)
        {
            Destroy(gameObject);
        }

        Enemy hittedEnemy = collision.collider.GetComponent<Enemy>();

        // Other enemy hits current enemy
        if (hittedEnemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5f)
        {
            Destroy(gameObject);
        }
    }
}
