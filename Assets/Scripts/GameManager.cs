using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState{ loading, inGame, gameOver }

    public GameState gameState;
    
    public List<GameObject> targetPrefabs;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public Button restartButton;

    private int _score;

    private int score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 99999);
        }

        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI titleText;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public void StartGame()
    {
        gameState = GameState.inGame;

        titleText.gameObject.SetActive(false);
        easyButton.gameObject.SetActive(false);
        mediumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Puntuación: \n" + score;
    }

    public void GameOver()
    {
        gameState = GameState.gameOver;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
