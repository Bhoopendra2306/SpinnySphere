using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePanel : MonoBehaviour {
    private Text m_scoreText;
    private Text m_coinText;
	// Use this for initialization
	void Start () {
        m_scoreText = transform.Find("Score").GetComponent<Text>();
        m_coinText = transform.Find("Coin").GetComponent<Text>();
        ShowCoinNum();
    }
	
    public void ShowScoreNum(int num)
    {
        m_scoreText.text = num.ToString();
    }

    public void ShowCoinNum()
    {
        m_coinText.text = ScoreManager.Instance.Coin.ToString();
    }
}
