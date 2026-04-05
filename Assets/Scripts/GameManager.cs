using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int maxScore { get; private set; }
    public Collectible[] allCollectible;

    public bool gameWin;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeGame();
    }

    private void Update()
    {
        if (score >= maxScore)
        {
            Time.timeScale = 0f;
            score = maxScore;
            gameWin = true;
            UIManager.Instance.WinGameUI(gameWin);
        }
    }

    private void CounterScoreMax()
    {
        allCollectible = FindObjectsByType<Collectible>(FindObjectsSortMode.InstanceID);
        foreach (var collectible in allCollectible)
        {
            maxScore += collectible.points;
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UIManager.Instance.ChangeScoreUI();
    }

    private void InitializeGame()
    {
        Time.timeScale = 1f;
        score = 0;
        maxScore = 0;
        CounterScoreMax();
        gameWin = false;
        UIManager.Instance.WinGameUI(gameWin);
        UIManager.Instance.LoseGameUI(gameWin);
        UIManager.Instance.ChangeScoreUI();
    }

    public void ResetGame()
    {
        StartCoroutine(LoadAndInit());
    }

    private IEnumerator LoadAndInit()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        while (!load.isDone)
            yield return null;

        InitializeGame();
    }
}
