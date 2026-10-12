using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    public float padding = 0.5f;
    public TMP_Text scoreText;   // drag the Score Label here

    private float timer;
    private int score;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        Camera cam = Camera.main;
        float halfWidth = cam.orthographicSize * cam.aspect - padding;
        float x = Random.Range(-halfWidth, halfWidth);
        float y = cam.orthographicSize + 1f; // just above the top of the screen

        GameObject enemy = EnemyPool.Instance.Get();
        enemy.transform.position = new Vector3(x, y, 0f);

        score++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}