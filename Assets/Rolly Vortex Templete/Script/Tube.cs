using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Tube : SpawnItem
{
    public GameObject model;

    protected override float Extent
    {
        get
        {
            return 20;
        }
    }
}
