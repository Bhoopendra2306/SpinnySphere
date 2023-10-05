using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour {

    public bool bRotate = false;
    public float LeftAngle = 60;
    public float RightAngle = 60;
    private float m_Angle = 0;
    public float RotateSpeed = 100;
    public int Dir = 1;
    public int Type = 0;
    public int TargetAngle = 60;
	// Update is called once per frame

	void Update () {
        if(bRotate && Vector3.Distance(transform.localScale, Vector3.one)<0.01f)
        {
            if(Type == 0)
            {
                transform.Rotate(Vector3.forward, Dir * RotateSpeed * Time.deltaTime, Space.Self);
                m_Angle += RotateSpeed * Time.deltaTime;
                float LimitAngle = Dir > 0 ? RightAngle : LeftAngle;
                if (m_Angle >= LimitAngle)
                {
                    m_Angle = 0;
                    Dir = -Dir;
                }
            }
            else if(Type == 1)
            {
                transform.Rotate(Vector3.forward, Dir * RotateSpeed * Time.deltaTime, Space.Self);
                m_Angle += RotateSpeed * Time.deltaTime;
                if(m_Angle >= TargetAngle)
                {
                    bRotate = false;
                }
            }

        }
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 5*Time.deltaTime);
	}

    void OnDisable()
    {
        m_Angle = 0;
    }
}
