using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultPanel : MonoBehaviour {
    private Text m_scoreText;
    private Text m_bestScoreText;
    private Text m_coinNumText;
    private Button m_btnRestart;
    // Use this for initialization
    void Awake () {
        m_scoreText = transform.Find("Result/Score").GetComponent<Text>();
        m_bestScoreText = transform.Find("Result/BestScore").GetComponent<Text>();
        m_coinNumText = transform.Find("Result/Coin/num").GetComponent<Text>();
        m_btnRestart = transform.Find("Restart").GetComponent<Button>();
        m_btnRestart.onClick.AddListener(Restart);
    }
	
    public void ShowResult()
    {
        m_scoreText.text = "Score:" + ScoreManager.Instance.Score.ToString();
        m_bestScoreText.text = "BestScore:" + ScoreManager.Instance.BestScore.ToString();
        m_coinNumText.text = ScoreManager.Instance.Coin.ToString();
        ScoreManager.Instance.ShowDataResult();
    }

    public void Restart()
    {
        SceneManager.LoadScene("main");
    }
}
