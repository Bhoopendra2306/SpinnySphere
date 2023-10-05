using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    None,
    StartPanel,
    SkinPanel,
    TubePanel,
    MessagePanel,
    BuyPanel,
    ResultPanel,
    GamePanel,
}

public class UIManager : MonoBehaviour {
    private Dictionary<UIType, GameObject> m_dicUIPanle = new Dictionary<UIType, GameObject>();
    private static UIManager instance;
    public static UIManager Instacne
    {
        get
        {
            return instance;
        }
    }

    public GameObject StartPanel;
    public GameObject SkinPanel;
    public GameObject TubePanel;
    public GameObject MessagePanel;
    public GameObject BuyPanel;
    public GameObject ResultPanel;
    public GameObject GamePanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        m_dicUIPanle.Add(UIType.StartPanel, StartPanel);
        m_dicUIPanle.Add(UIType.SkinPanel, SkinPanel);
        m_dicUIPanle.Add(UIType.TubePanel, TubePanel);
        m_dicUIPanle.Add(UIType.MessagePanel, MessagePanel);
        m_dicUIPanle.Add(UIType.BuyPanel, BuyPanel);
        m_dicUIPanle.Add(UIType.ResultPanel, ResultPanel);
        m_dicUIPanle.Add(UIType.GamePanel, GamePanel);

    }

    public void Open(UIType type)
    {
        if (m_dicUIPanle.ContainsKey(type))
        {
            m_dicUIPanle[type].SetActive(true);
        }
    }

    public void Close(UIType type)
    {
        if(m_dicUIPanle.ContainsKey(type))
        {
            m_dicUIPanle[type].SetActive(false);
        }
    }

    public void ShowMessageBox(string text)
    {
        MessagePanel.SetActive(true);
        MessagePanel.GetComponent<MessagePanel>().ShowMessageBox(text);
    }

    public void ShowBuyPanel(TubeTexture tube)
    {
        BuyPanel.SetActive(true);
        BuyPanel.GetComponent<BuyPanel>().Show(tube);
    }

    public void ShowResult()
    {
        ResultPanel.SetActive(true);
        ResultPanel.GetComponent<ResultPanel>().ShowResult();
    }

    public void ShowScoreNum(int num)
    {
        GamePanel.SetActive(true);
        GamePanel.GetComponent<GamePanel>().ShowScoreNum(num);
    }

    public void ShowCoinNum()
    {
        GamePanel.GetComponent<GamePanel>().ShowCoinNum();
    }

    public void ShowTotalCoinNum()
    {
        TubePanel.GetComponent<TubePanel>().ShowCoinNum();
    }
}
