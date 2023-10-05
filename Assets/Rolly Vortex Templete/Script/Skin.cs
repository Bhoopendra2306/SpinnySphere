using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skin : MonoBehaviour, IPointerClickHandler
{

    public int TargetValue = 50;
    public AchieveType type = AchieveType.TotalScore;
    public int SkinIndex = 0;
    private int curValue = 0;
    public Image ProgressImage;
    private Image CheckImage;
    
    void Awake()
    {
        CheckImage = transform.Find("check").GetComponent<Image>();
    }

    void OnEnable()
    {
        CheckImage.gameObject.SetActive(false);

        if (type == AchieveType.TotalScore)
        {
            curValue = PlayerPrefs.GetInt(PlayerPrefTag.TotalScore);
        }
        else if(type == AchieveType.PlayerTimes)
        {
            curValue = PlayerPrefs.GetInt(PlayerPrefTag.PlayerTimes);
        }
        else if(type == AchieveType.BestScore)
        {
            curValue = PlayerPrefs.GetInt(PlayerPrefTag.BestScore);
        }
        if(curValue >= TargetValue)
        {
            if(SkinIndex == PlayerPrefs.GetInt(PlayerPrefTag.SkinIndex))
            {
                CheckImage.gameObject.SetActive(true);
            }
            else
            {
                CheckImage.gameObject.SetActive(false);
            }
        }
        ProgressImage.fillAmount = 1 - curValue * 1.0f / TargetValue;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(curValue >= TargetValue)
        {
            PlayerPrefs.SetInt(PlayerPrefTag.SkinIndex, SkinIndex);
            GameManager.Instacne.GeneratePlayer(SkinIndex);
            UIManager.Instacne.Close(UIType.SkinPanel);
        }
        else
        {
            string text = "At least {0} {1} ({2} / {0})";
            if (type == AchieveType.TotalScore)
            {
                text = string.Format(text, TargetValue.ToString(), "Scores", curValue.ToString());
            }
            else if(type == AchieveType.PlayerTimes)
            {
                text = string.Format(text, TargetValue.ToString(), "Play Times", curValue.ToString());
            }
            else if(type == AchieveType.BestScore)
            {
                text = string.Format(text, TargetValue.ToString(), "BestScore", curValue.ToString());
            }
            UIManager.Instacne.ShowMessageBox(text);
        }
    }
}
