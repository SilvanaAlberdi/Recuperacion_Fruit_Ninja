using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;

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
    
    void Start()
    {
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
