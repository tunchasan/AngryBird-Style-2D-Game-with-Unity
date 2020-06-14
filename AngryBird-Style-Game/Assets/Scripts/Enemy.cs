using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird hittedBird = collision.collider.GetComponent<Bird>();

        // Bird hits current enemy
        if (hittedBird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);

            return;
        }

        Enemy hittedEnemy = collision.collider.GetComponent<Enemy>();

        // Other enemy hits current enemy
        if (hittedEnemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5f)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
