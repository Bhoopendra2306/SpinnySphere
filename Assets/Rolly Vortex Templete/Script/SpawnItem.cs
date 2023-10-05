using System;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Spawner.Instance == null)
        {
            return;
        }
        if (Application.isPlaying && (this.Top < Spawner.Instance.Back))
        {
            ObjectPoolManager.instance.BackToPool(gameObject, gameObject.name);
        }
    }

    protected virtual float Extent
    {
        get
        {
            return 0f;
        }
    }

    private float Top
    {
        get
        {
            return (base.transform.position.z + this.Extent);
        }
    }
}

