using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            ObjectPoolManager.instance.BackToPool(transform.parent.gameObject, "Coin");
            ScoreManager.Instance.AddCoin(1);
            UIManager.Instacne.ShowCoinNum();
            AudioManager.Instacne.PlayCoinAudio();
        }
    }
}