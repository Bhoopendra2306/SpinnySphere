using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBarrageType
{
    Custom,
    Random,
}

public enum eRotateType
{
    Loop,
    Target,
}

public enum eDirType
{
    Left,
    Right,
    Random,
}

public class Rule : MonoBehaviour {
    public bool Active = true;
    public string CubeId;
    public eBarrageType BarrageType = eBarrageType.Custom;
    public int CubeNum = 5;
    public List<int> CubePosList = new List<int>();
    public bool bRotate = false;
    public float LeftAngle = 60;
    public float RightAngle = 60;
    public float RotateSpeed = 100;
    public eDirType Dir = eDirType.Left;
    public eRotateType type = 0;
    public int TargetAngle = 60;

    public bool GetRotate()
    {
        return bRotate;
    }

    public int GetDir()
    {
        if(Dir == eDirType.Random)
        {
            return Random.Range(0, 2) > 0 ? 1 : -1;
        }
        if (Dir == eDirType.Left)
            return -1;
        return 1;
    }

    public List<int> GetList()
    {
        List<int> result = new List<int>();
        if(BarrageType == eBarrageType.Random)
        {
            int count = 0;
            while(count != CubeNum)
            {
                int index = Random.Range(0, 18);
                if(!result.Contains(index))
                {
                    result.Add(index);
                    count++;
                }
            }
            return result;
        }
        return CubePosList;
    }
}
