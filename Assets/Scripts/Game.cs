using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField] private Enemy _enemyPrefab;
    private List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScore;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
        highScore.text = "Record: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    #region Enemy

    private IEnumerator CreateEnemy()
    {
        while (enemies.Count < 5)
        {
            int y = Random.Range(0, 3);

            Enemy newEnemy = Instantiate(_enemyPrefab, new Vector3(10, y, 8), Quaternion.identity);
            enemies.Add(newEnemy);

            yield return new WaitForSeconds(1.5f);
        }
    }

    public void DeleteEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    #endregion

    public void Restart()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
        SceneManager.LoadScene(0);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
