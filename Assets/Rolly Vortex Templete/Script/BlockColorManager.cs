using System;
using UnityEngine;

public class BlockColorManager : MonoBehaviour
{
    [SerializeField]
    private float a = 1f;
    [SerializeField]
    private float b = 210f;
    [SerializeField]
    private int blockValueBegin = 1;
    [SerializeField]
    private int blockValueEnd = 50;
    [SerializeField]
    private float hBegin = 0;
    [SerializeField]
    private float hEnd = 180f;
    private static BlockColorManager instance;
    [SerializeField]
    private float s = 210f;
    //public bool useColor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("A singleton can only be instantiated once!");
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }

    public Color GetBlockColor(int blockValue)
    {
        HSBColor hsbColor;
        float t = Mathf.InverseLerp((float)this.blockValueBegin, (float)this.blockValueEnd, (float)blockValue);
        float num2 = Mathf.Lerp(this.hBegin, this.hEnd, t);
        hsbColor.a = this.a;
        hsbColor.h = num2 / 360f;
        hsbColor.s = this.s / 255f;
        hsbColor.b = this.b / 255f;
        return hsbColor.ToColor();
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public static BlockColorManager Instance
    {
        get
        {
            return instance;
        }
    }
}

