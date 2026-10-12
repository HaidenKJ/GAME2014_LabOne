using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 4f;
    private float bottomLimit;

    void OnEnable()
    {
        Camera cam = Camera.main;
        bottomLimit = -cam.orthographicSize - 1f;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < bottomLimit)
        {
            EnemyPool.Instance.Return(gameObject);
        }
    }

    // Needs: BoxCollider2D (Is Trigger) on the enemy prefab,
    // BoxCollider2D + Rigidbody2D (Kinematic) on the player, player tagged "Player"
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by enemy");
            SceneManager.LoadScene("End");
        }
    }
}