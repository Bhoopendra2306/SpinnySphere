using System;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    private float currentVelocity;
    private float currentrotation;
    private float offset;
    public float smoothTime = 0.5f;
    public float smoothrotationTime = 0.5f;
    private float m_curpos;
    public float distance = 0.01f;
    public float x_offsetSpeed = 100;
    public Material tube;
    public Transform PlayerTransform;
    private void FixedUpdate()
    {
        this.UpdateFollow(Time.deltaTime);
    }

    void Update()
    {
        float zpos = transform.position.z;
        if (zpos - m_curpos > distance)
        {
            Vector2 offset = tube.GetTextureOffset("_MainTex");
            offset.x -= x_offsetSpeed * Time.deltaTime;
            tube.SetTextureOffset("_MainTex", offset);
            m_curpos = zpos;
        }

    }

    void Start()
    {
        this.offset = base.transform.position.z - PlayerTransform.position.z;
        m_curpos = transform.position.z;
    }

    private void UpdateFollow(float deltaTime)
    {
        if (PlayerTransform != null)
        {
            Vector3 vector = PlayerTransform.position;
            Vector3 position = base.transform.position;
            position.z = Mathf.SmoothDamp(position.z - this.offset, vector.z, ref this.currentVelocity, this.smoothTime, float.PositiveInfinity, deltaTime) + this.offset;
            base.transform.position = position;
        }
    }

    void OnDestroy()
    {
        tube.SetTextureOffset("_MainTex", Vector2.zero);
    }
}

