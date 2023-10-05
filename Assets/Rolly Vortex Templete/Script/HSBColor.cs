using System;
using System.Runtime.InteropServices;
using UnityEngine;

public struct HSBColor
{
    public float h;
    public float s;
    public float b;
    public float a;
    public HSBColor(float h, float s, float b, float a)
    {
        this.h = h;
        this.s = s;
        this.b = b;
        this.a = a;
    }

    public HSBColor(float h, float s, float b)
    {
        this.h = h;
        this.s = s;
        this.b = b;
        this.a = 1f;
    }

    public HSBColor(Color col)
    {
        HSBColor color = RGB2HSB(col);
        this.h = color.h;
        this.s = color.s;
        this.b = color.b;
        this.a = color.a;
    }


    public static HSBColor RGB2HSB(Color color)
    {
        HSBColor color2 = new HSBColor(0f, 0f, 0f, color.a);
        float r = color.r;
        float g = color.g;
        float b = color.b;
        float num4 = Mathf.Max(r, Mathf.Max(g, b));
        if (num4 > 0f)
        {
            float num5 = Mathf.Min(r, Mathf.Min(g, b));
            float num6 = num4 - num5;
            if (num4 > num5)
            {
                if (g == num4)
                {
                    color2.h = (((b - r) / num6) * 60f) + 120f;
                }
                else if (b == num4)
                {
                    color2.h = (((r - g) / num6) * 60f) + 240f;
                }
                else if (b > g)
                {
                    color2.h = (((g - b) / num6) * 60f) + 360f;
                }
                else
                {
                    color2.h = ((g - b) / num6) * 60f;
                }
                if (color2.h < 0f)
                {
                    color2.h += 360f;
                }
            }
            else
            {
                color2.h = 0f;
            }
            color2.h *= 0.002777778f;
            color2.s = (num6 / num4) * 1f;
            color2.b = num4;
        }
        return color2;
    }

    public static Color HSB2RGB(HSBColor hsbColor)
    {
        float b = hsbColor.b;
        float num2 = hsbColor.b;
        float num3 = hsbColor.b;
        if (hsbColor.s != 0f)
        {
            float num4 = hsbColor.b;
            float num5 = hsbColor.b * hsbColor.s;
            float num6 = hsbColor.b - num5;
            float num7 = hsbColor.h * 360f;
            if (num7 < 60f)
            {
                b = num4;
                num2 = ((num7 * num5) / 60f) + num6;
                num3 = num6;
            }
            else if (num7 < 120f)
            {
                b = ((-(num7 - 120f) * num5) / 60f) + num6;
                num2 = num4;
                num3 = num6;
            }
            else if (num7 < 180f)
            {
                b = num6;
                num2 = num4;
                num3 = (((num7 - 120f) * num5) / 60f) + num6;
            }
            else if (num7 < 240f)
            {
                b = num6;
                num2 = ((-(num7 - 240f) * num5) / 60f) + num6;
                num3 = num4;
            }
            else if (num7 < 300f)
            {
                b = (((num7 - 240f) * num5) / 60f) + num6;
                num2 = num6;
                num3 = num4;
            }
            else if (num7 <= 360f)
            {
                b = num4;
                num2 = num6;
                num3 = ((-(num7 - 360f) * num5) / 60f) + num6;
            }
            else
            {
                b = 0f;
                num2 = 0f;
                num3 = 0f;
            }
        }
        return new Color(Mathf.Clamp01(b), Mathf.Clamp01(num2), Mathf.Clamp01(num3), hsbColor.a);
    }

    public Color ToColor()
    {
        return HSB2RGB(this);
    }

    public override string ToString()
    {
        object[] objArray1 = new object[] { "H:", this.h, " S:", this.s, " B:", this.b };
        return string.Concat(objArray1);
    }

}

