using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject panelWin, panelLose;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scoreText.text = "0x/" + GameManager.Instance.maxScore.ToString() + "x";
        
        panelWin.SetActive(false);
        panelLose.SetActive(false);
    }

    public void ChangeScoreUI()
    {
        scoreText.text = GameManager.Instance.score.ToString() + "x/" + GameManager.Instance.maxScore.ToString() + "x";
    }

    public void WinGameUI(bool win)
    {
        panelWin.SetActive(win);
    }

    public void LoseGameUI(bool lose)
    {
        panelLose.SetActive(lose);
    }
}
