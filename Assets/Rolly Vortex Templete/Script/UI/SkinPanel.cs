using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour {

    private Button m_btnClose;

    void Start()
    {
        m_btnClose = transform.Find("Close").GetComponent<Button>();
        m_btnClose.onClick.AddListener(Close);
    }


    private void Close()
    {
        UIManager.Instacne.Close(UIType.SkinPanel);
    }
}
