using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Rigidbody m_Rigidbody;
    private bool bActive = false;
    
    public SphereCollider SphereCollider;

    private Vector3 moveDirection;
    private float degress;
    private Vector3 m_CurrPos;
    public float R = 2.3333f;
    public bool Active
    {
        get
        {
            return bActive;
        }
        set
        {
            bActive = value;
            SphereCollider.enabled = bActive;
        }
    }

    float Angle_360(Vector3 from_, Vector3 to_)
    {
        from_.z = to_.z = 0;
        Vector3 v3 = Vector3.Cross(from_, to_);
        if (v3.z >= 0)
            return 180 - Vector3.Angle(from_, to_);
        else
            return Vector3.Angle(from_, to_) - 180;
    }

    float Angle_180(Vector3 from_, Vector3 to_)
    {
        from_.z = to_.z = 0;
        Vector3 v3 = Vector3.Cross(from_, to_);
        if (v3.z >= 0)
            return Vector3.Angle(from_, to_);
        else
            return -Vector3.Angle(from_, to_);
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (GameManager.Instacne.GameState != GameStateEnum.StartGame)
            return;

        if (bActive)
        {
            //Vector2 from = new Vector2(ballSnake.m_currPos.x, ballSnake.m_currPos.y);
            //Vector2 to = new Vector2(transform.position.x, transform.position.y);
            //float angle = Angle_180(from, to);

            //ballSnake.Angle += angle;

            //ballSnake.m_currPos = transform.position;
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, ballSnake.Angle));
            //degress = 0;
            //if(Application.platform == RuntimePlatform.WindowsEditor)
            //{
            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        ballSnake.mouseCurrentPos = ballSnake.mousePreviousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //    }
            //    else if (Input.GetMouseButton(0))
            //    {
            //        ballSnake.mouseCurrentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //        float deltaMousePos = (ballSnake.mousePreviousPos.x - ballSnake.mouseCurrentPos.x);
            //        //float sign = Mathf.Sign(ballSnake.mousePreviousPos.x - ballSnake.mouseCurrentPos.x);
            //        int speed = (int)(deltaMousePos * movementManager.DragSpeed * 400 * -1);
            //        speed = speed * 2;
            //    }
            //}
            //else if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            //{
            //    if (Input.touchCount > 0)
            //    {
            //        if (Input.touches[0].phase == TouchPhase.Moved)
            //        {
            //            int speed = (int)(Input.touches[0].deltaPosition.x * movementManager.DragSpeed);

            //            speed = Mathf.Clamp(speed, movementManager.MinHorizontalSpeed, movementManager.MaxHorizontalSpeed);
            //            degress = speed;
            //        }
            //    }
            //}



            degress = degress / 180 * Mathf.PI;
            Vector2 pos = transform.position;
            pos = pos.normalized * R;
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            float x = pos.x * Mathf.Cos(degress) - pos.y * Mathf.Sin(degress);
            float y = pos.x * Mathf.Sin(degress) + pos.y * Mathf.Cos(degress);
            m_CurrPos = new Vector3(x, y, 0);
            moveDirection = m_CurrPos - transform.position;
            

            Vector3 v = moveDirection / Time.fixedDeltaTime;
            
            m_Rigidbody.velocity = Vector3.Lerp(m_Rigidbody.velocity, v, 0.1f);
            //m_Rigidbody.velocity = moveDirection/Time.fixedDeltaTime;
        }

    }

    public Vector3 Position_Visual
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
    
    public BallData BallInfo
    {
        get
        {
            BallData data = new BallData();
            data.pos = transform.position;
            data.rotation = transform.rotation;
            return data;
        }
        set
        {
            transform.position = value.pos;
            //transform.rotation = value.rotation;
            //transform.Rotate(new Vector3(0, 0, value.angle - m_angel), Space.World);
            transform.rotation = value.rotation;//Quaternion.Euler(new Vector3(0, 0, m_angel));

        }
    }


    public Vector3 Position_Physical
    {
        get
        {
            return m_Rigidbody.position;
        }
        set
        {
            this.m_Rigidbody.position = value;
            base.transform.position = value;
        }
    }

    public void ResetRigidbody()
    {
        m_Rigidbody.velocity = Vector3.zero;
    }
}
