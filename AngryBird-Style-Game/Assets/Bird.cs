using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;

    private bool _birdWasLaunced;

    private float _timeSittingAround;

    [SerializeField]
    private float _launchForce = 300;

    [SerializeField]
    private float _birdGroundthresholdTime = 3;


    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_birdWasLaunced && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10  ||
            transform.position.y < -10 ||
            transform.position.x > 10  ||
            transform.position.x < -10 ||
            _timeSittingAround > _birdGroundthresholdTime)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directiontoInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directiontoInitialPosition * _launchForce);

        GetComponent<Rigidbody2D>().gravityScale = 1;

        _birdWasLaunced = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
