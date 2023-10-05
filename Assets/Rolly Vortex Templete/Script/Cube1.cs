using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Cube1 : SpawnItem
{
    public GameObject model;

    protected override float Extent
    {
        get
        {
            return 0f;
        }
    }
}
