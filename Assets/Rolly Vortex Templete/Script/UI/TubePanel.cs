using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TubePanel : MonoBehaviour {
    private Button m_btnClose;
    private Text m_coin;
    void Awake ()
    {
        m_btnClose = transform.Find("Close").GetComponent<Button>();
        m_btnClose.onClick.AddListener(Close);

        m_coin = transform.Find("Coin").GetComponent<Text>();
    }

    public void ShowCoinNum()
    {
        m_coin.text = ScoreManager.Instance.OwnedCoin.ToString();
    }

    private void Close()
    {
        UIManager.Instacne.Close(UIType.TubePanel);
    }
}
