using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int bestScore = 0;
    private int totalScore = 0;
    private int playerTimes = 0;
    private int coin = 0;
    private int ownedCoin = 0;
    public GameObject GameResult;
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance != null)
                return instance;
            else
                return null;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        ownedCoin = PlayerPrefs.GetInt(PlayerPrefTag.Coin);
        bestScore = PlayerPrefs.GetInt(PlayerPrefTag.BestScore);
        totalScore = PlayerPrefs.GetInt(PlayerPrefTag.TotalScore);
        playerTimes = PlayerPrefs.GetInt(PlayerPrefTag.PlayerTimes);
    }

    public void AddScore(int num)
    {
        score += num;
        
        UIManager.Instacne.ShowScoreNum(score);
    }

    public void AddCoin(int num)
    {
        coin += num;
        ownedCoin += num;
        PlayerPrefs.SetInt(PlayerPrefTag.Coin, ownedCoin);
    }


    public void ConsumeCoin(int price)
    {
        ownedCoin -= price;
        PlayerPrefs.SetInt(PlayerPrefTag.Coin, ownedCoin);
        UIManager.Instacne.ShowTotalCoinNum();
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public int BestScore
    {
        get
        {
            return bestScore;
        }
    }

    public void ShowDataResult()
    {
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(PlayerPrefTag.BestScore, score);
        }
        playerTimes++;
        PlayerPrefs.SetInt(PlayerPrefTag.PlayerTimes, playerTimes);
        totalScore += score;
        PlayerPrefs.SetInt(PlayerPrefTag.TotalScore, totalScore);

    }


    public int Coin
    {
        get
        {
            return coin;
        }
    }

    public int OwnedCoin
    {
        get
        {
            return ownedCoin;
        }
    }


    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
