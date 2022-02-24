using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeBetweenSpawnLow = 0.5f;
    public float timeBetweenSpawnHigh = 3f;

    float spawnCools;

    Vector2 bounds;
    Vector3 spawnPosition;

    public Text scoreText;
    int score;

    public bool gameOver;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        spawnCools = Random.Range(timeBetweenSpawnLow, timeBetweenSpawnHigh);
        score = 0;
        scoreText.text = "Scores: " + score.ToString();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCools > 0)
            spawnCools -= Time.deltaTime;
        else
            SpawnEnemy();
        scoreText.text = "Scores: " + score.ToString();

        if (gameOver && Input.anyKeyDown)
        {
            Restart();
        }

    }
    void SpawnEnemy()
    {
        spawnPosition = new Vector3(Random.Range(-bounds.x + 1f, bounds.x - 1f), bounds.y + Random.Range(0.25f, 3f), 0f);
        Instantiate(enemies[Random.Range(0, enemies.Length)],spawnPosition,Quaternion.Euler(0,0,180));
        spawnCools = Random.Range(timeBetweenSpawnLow, timeBetweenSpawnHigh);
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void AddScore(int amount)
    {
        score += amount;

    }
}
