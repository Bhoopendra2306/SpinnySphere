using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MessagePanel : MonoBehaviour , IPointerClickHandler{

    public Text  m_text; 
    // Use this for initialization

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }

    public void ShowMessageBox(string text)
    {
        gameObject.SetActive(true);
        m_text.text = text;
    }
}
