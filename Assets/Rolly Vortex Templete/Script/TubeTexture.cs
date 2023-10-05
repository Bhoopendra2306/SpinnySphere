using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TubeTexture : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public Image Icon;
    [HideInInspector]
    public Image Check;
    private Transform Mask;
    private Text PriceText;
    public int SkinIndex = 0;
    public int Price;
    private bool bOwned = false;
	// Use this for initialization
	void Awake () {
        Mask = transform.Find("mask");
        PriceText = Mask.Find("Text").GetComponent<Text>();
        Icon = transform.Find("Icon").GetComponent<Image>();
        Check = transform.Find("check").GetComponent<Image>();
        
	}
	
    void OnEnable()
    {
        RefreshUI();
    }

    public void BuySuccess()
    {
        string skin = PlayerPrefs.GetString(PlayerPrefTag.TubeSkin);
        skin = skin + '$' + SkinIndex.ToString();
        PlayerPrefs.SetString(PlayerPrefTag.TubeSkin, skin);
        RefreshUI();
    }

    public void RefreshUI()
    {
        PriceText.text = Price.ToString();
        Check.gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey(PlayerPrefTag.TubeSkin))
        {
            PlayerPrefs.SetString(PlayerPrefTag.TubeSkin, "0");
        }
        string skin = PlayerPrefs.GetString(PlayerPrefTag.TubeSkin);
        string[] skins = skin.Split('$');
        bOwned = false;
        for (int i=0; i<skins.Length; i++)
        {
            if(int.Parse(skins[i]) == SkinIndex)
            {
                bOwned = true;
                if(SkinIndex == PlayerPrefs.GetInt(PlayerPrefTag.TubeTexture))
                {
                    Check.gameObject.SetActive(true);
                }
                break;
            }
            
        }
        if(bOwned)
        {
            Mask.gameObject.SetActive(false);
        }
        else
        {
            Mask.gameObject.SetActive(true);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(bOwned)
        {
            GameManager.Instacne.SetTubeMaterial(SkinIndex);
            PlayerPrefs.SetInt(PlayerPrefTag.TubeTexture, SkinIndex);
            UIManager.Instacne.Close(UIType.TubePanel);
        }
        else
        {
            UIManager.Instacne.ShowBuyPanel(this);
        }
    }
}
