using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BuyPanel : MonoBehaviour {
    private Image Icon;
    private Button btn_Cancel;
    private Button btn_OK;
    private TubeTexture tube;
    private Text PriceText;
    // Use this for initialization
    void Awake () {
        Icon = transform.Find("MessageBox/Icon").GetComponent<Image>();
        PriceText = Icon.transform.Find("Price").GetComponent<Text>();
        btn_Cancel = transform.Find("MessageBox/Cancel").GetComponent<Button>();
        btn_OK = transform.Find("MessageBox/OK").GetComponent<Button>();
        btn_Cancel.onClick.AddListener(Cancel);
        btn_OK.onClick.AddListener(Buy);
    }

    void Buy()
    {
        int coin = PlayerPrefs.GetInt(PlayerPrefTag.Coin);
        if(coin >= tube.Price)
        {
            coin -= tube.Price;
            ScoreManager.Instance.ConsumeCoin(tube.Price);
            tube.BuySuccess();
            gameObject.SetActive(false);
        }
    }

    void Cancel()
    {
        UIManager.Instacne.Close(UIType.BuyPanel);
    }

    public void Show(TubeTexture tube)
    {
        this.tube = tube;
        gameObject.SetActive(true);
        Icon.sprite = tube.Icon.sprite;
        int coin = PlayerPrefs.GetInt(PlayerPrefTag.Coin);
        PriceText.text = coin.ToString() + "/" + tube.Price.ToString();
    }
}
